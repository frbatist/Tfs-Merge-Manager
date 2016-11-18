using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace TFS
{
    public class ListSelectionWrapper<T> : List<ObjectSelectionWrapper<T>>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// No property on the object is specified for display purposes, so simple ToString() operation 
        /// will be performed. And no Counts will be displayed
        /// </summary>
        public ListSelectionWrapper(IEnumerable source) : this(source, false) { }
        /// <summary>
        /// No property on the object is specified for display purposes, so simple ToString() operation 
        /// will be performed.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, bool showCounts)
            : base()
        {
            _Source = source;
            _ShowCounts = showCounts;
            if (_Source is IBindingList)
                ((IBindingList)_Source).ListChanged += new ListChangedEventHandler(ListSelectionWrapper_ListChanged);
            Populate();
        }
        /// <summary>
        /// A Display "Name" property is specified. ToString() will not be performed on items.
        /// This is specifically useful on DataTable implementations, or where PropertyDescriptors are used to read the values.
        /// If a PropertyDescriptor is not found, a Property will be used.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, string usePropertyAsDisplayName) : this(source, false, usePropertyAsDisplayName) { }
        /// <summary>
        /// A Display "Name" property is specified. ToString() will not be performed on items.
        /// This is specifically useful on DataTable implementations, or where PropertyDescriptors are used to read the values.
        /// If a PropertyDescriptor is not found, a Property will be used.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, bool showCounts, string usePropertyAsDisplayName)
            : this(source, showCounts)
        {
            _DisplayNameProperty = usePropertyAsDisplayName;
        }

        #endregion

        #region PRIVATE PROPERTIES

        /// <summary>
        /// Is a Count indicator used.
        /// </summary>
        private bool _ShowCounts;
        /// <summary>
        /// The original List of values wrapped. A "Selected" and possibly "Count" functionality is added.
        /// </summary>
        private IEnumerable _Source;
        /// <summary>
        /// Used to indicate NOT to use ToString(), but read this property instead as a display value.
        /// </summary>
        private string _DisplayNameProperty = null;

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// When specified, indicates that ToString() should not be performed on the items. 
        /// This property will be read instead. 
        /// This is specifically useful on DataTable implementations, where PropertyDescriptors are used to read the values.
        /// </summary>
        public string DisplayNameProperty
        {
            get { return _DisplayNameProperty; }
            set { _DisplayNameProperty = value; }
        }
        /// <summary>
        /// Builds a concatenation list of selected items in the list.
        /// </summary>
        public string SelectedNames
        {
            get
            {
                string Text = "";
                foreach (ObjectSelectionWrapper<T> Item in this)
                    if (Item.Selected)
                        Text += (
                            string.IsNullOrEmpty(Text)
                            ? String.Format("\"{0}\"", Item.Name)
                            : String.Format(" & \"{0}\"", Item.Name));
                return Text;
            }
        }
        /// <summary>
        /// Indicates whether the Item display value (Name) should include a count.
        /// </summary>
        public bool ShowCounts
        {
            get { return _ShowCounts; }
            set { _ShowCounts = value; }
        }

        #endregion

        #region HELPER MEMBERS

        /// <summary>
        /// Reset all counts to zero.
        /// </summary>
        public void ClearCounts()
        {
            foreach (ObjectSelectionWrapper<T> Item in this)
                Item.Count = 0;
        }
        /// <summary>
        /// Creates a ObjectSelectionWrapper item.
        /// Note that the constructor signature of sub classes classes are important.
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        private ObjectSelectionWrapper<T> CreateSelectionWrapper(IEnumerator Object)
        {
            Type[] Types = new Type[] { typeof(T), this.GetType() };
            ConstructorInfo CI = typeof(ObjectSelectionWrapper<T>).GetConstructor(Types);
            if (CI == null)
                throw new Exception(String.Format(
                              "The selection wrapper class {0} must have a constructor with ({1} Item, {2} Container) parameters.",
                              typeof(ObjectSelectionWrapper<T>),
                              typeof(T),
                              this.GetType()));
            object[] parameters = new object[] { Object.Current, this };
            object result = CI.Invoke(parameters);
            return (ObjectSelectionWrapper<T>)result;
        }

        public ObjectSelectionWrapper<T> FindObjectWithItem(T Object)
        {
            return Find(new Predicate<ObjectSelectionWrapper<T>>(
                            delegate (ObjectSelectionWrapper<T> target)
                            {
                                return target.Item.Equals(Object);
                            }));
        }

        private void Populate()
        {
            Clear();
            /*
            for(int Index = 0; Index <= _Source.Count -1; Index++)
                Add(CreateSelectionWrapper(_Source[Index]));
             */
            IEnumerator Enumerator = _Source.GetEnumerator();
            if (Enumerator != null)
                while (Enumerator.MoveNext())
                    Add(CreateSelectionWrapper(Enumerator));
        }

        #endregion

        #region EVENT HANDLERS

        private void ListSelectionWrapper_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    Add(CreateSelectionWrapper((IEnumerator)((IBindingList)_Source)[e.NewIndex]));
                    break;
                case ListChangedType.ItemDeleted:
                    Remove(FindObjectWithItem((T)((IBindingList)_Source)[e.OldIndex]));
                    break;
                case ListChangedType.Reset:
                    Populate();
                    break;
            }
        }

        #endregion
    }

    public class ObjectSelectionWrapper<T> : INotifyPropertyChanged
    {
        public ObjectSelectionWrapper(T item, ListSelectionWrapper<T> container)
            : base()
        {
            _Container = container;
            _Item = item;
        }


        #region PRIVATE PROPERTIES

        /// <summary>
        /// Used as a count indicator for the item. Not necessarily displayed.
        /// </summary>
        private int _Count = 0;
        /// <summary>
        /// Is this item selected.
        /// </summary>
        private bool _Selected = false;
        /// <summary>
        /// A reference to the wrapped item.
        /// </summary>
        private T _Item;
        /// <summary>
        /// The containing list for these selections.
        /// </summary>
        private ListSelectionWrapper<T> _Container;

        #endregion

        #region PUBLIC PROPERTIES

        /// <summary>
        /// An indicator of how many items with the specified status is available for the current filter level.
        /// Thaught this would make the app a bit more user-friendly and help not to miss items in Statusses
        /// that are not often used.
        /// </summary>
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        /// <summary>
        /// A reference to the item wrapped.
        /// </summary>
        public T Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        /// <summary>
        /// The item display value. If ShowCount is true, it displays the "Name [Count]".
        /// </summary>
        public string Name
        {
            get
            {
                string Name = null;
                if (string.IsNullOrEmpty(_Container.DisplayNameProperty))
                    Name = Item.ToString();
                else if (Item is DataRow) // A specific implementation for DataRow
                    Name = ((DataRow)((Object)Item))[_Container.DisplayNameProperty].ToString();
                else
                {
                    PropertyDescriptorCollection PDs = TypeDescriptor.GetProperties(Item);
                    foreach (PropertyDescriptor PD in PDs)
                        if (PD.Name.CompareTo(_Container.DisplayNameProperty) == 0)
                        {
                            Name = (string)PD.GetValue(Item).ToString();
                            break;
                        }
                    if (string.IsNullOrEmpty(Name))
                    {
                        PropertyInfo PI = Item.GetType().GetProperty(_Container.DisplayNameProperty);
                        if (PI == null)
                            throw new Exception(String.Format(
                                      "Property {0} cannot be found on {1}.",
                                      _Container.DisplayNameProperty,
                                      Item.GetType()));
                        Name = PI.GetValue(Item, null).ToString();
                    }
                }
                return _Container.ShowCounts ? String.Format("{0} [{1}]", Name, Count) : Name;
            }
        }
        /// <summary>
        /// The textbox display value. The names concatenated.
        /// </summary>
        public string NameConcatenated
        {
            get { return _Container.SelectedNames; }
        }
        /// <summary>
        /// Indicates whether the item is selected.
        /// </summary>
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                if (_Selected != value)
                {
                    _Selected = value;
                    OnPropertyChanged("Selected");
                    OnPropertyChanged("NameConcatenated");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
