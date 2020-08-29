using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string>  _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set { 
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }
        private BindingList<string> _Cart;

        public BindingList<string> Cart
        {
            get { return _Cart; }
            set { _Cart = value; }
        }

        private int _ItemQuantity;

        public int ItemQuantity
        {
            get { return _ItemQuantity; }
            set { 
                _ItemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }
        private decimal _SubTotal;

        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private decimal _Tax;

        public decimal Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        private decimal _Net;

        public decimal Net
        {
            get { return _Net; }
            set { _Net = value; }
        }
        public bool CanAddToCart
        {
            get
            {

            }
            set
            {

            }
        }
        public bool CanRemoveFromCart
        {
            get
            {

            }
            set
            {

            }
        }
        public void AddToCart()
        {

        }
        public void RemoveFromCart()
        {

        }

    }
}
