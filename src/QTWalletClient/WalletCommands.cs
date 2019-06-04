namespace QTWalletClient
{
    public class WalletCommands
    {
        public static WalletCommands GetBlockCount = new WalletCommands("getblockcount");
        public static WalletCommands GetNewAddress = new WalletCommands("getnewaddress");
        public static WalletCommands GetBalance = new WalletCommands("getbalance");
        public static WalletCommands ListTransactions = new WalletCommands("listtransactions");

        private string _value;

        private WalletCommands(string val)
            => _value = val;

        internal string GetValue()
            => _value;
    }
}
