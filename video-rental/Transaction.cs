using System;

	namespace video_rental
{
    internal class Transaction
    {
        public int transactionID;
        public int customerID;
        public int inventoryItemID;
        public DateTime dateCheckedOut;
        public DateTime dateDue;
        public int TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        public int InventoryItemID
        {
            get { return inventoryItemID; }
            set { inventoryItemID = value; }
        }
        public DateTime DateCheckedOut
        {
            get { return dateCheckedOut; }
            set { dateCheckedOut = value; }
        }
        public DateTime DateDue
        {
            get { return dateDue; }
            set { dateDue = value; }
        }
    }
}
