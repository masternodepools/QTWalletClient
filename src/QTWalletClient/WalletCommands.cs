namespace QTWalletClient
{
    public class WalletCommands
    {
        public static WalletCommands GetBlockCount = new WalletCommands("getblockcount");
        public static WalletCommands GetNewAddress = new WalletCommands("getnewaddress");

        private string _value;

        private WalletCommands(string val)
        {
            _value = val;
        }

        internal string GetValue()
            => _value;
    }
}
