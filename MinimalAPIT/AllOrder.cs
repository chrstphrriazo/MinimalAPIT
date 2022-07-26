namespace MinimalAPIT
{
    public class AllOrder
    {
        public int Id { get; set; }
        public string clientOrderId { get; set; } = string.Empty;
        public string cummulativeQuoteQty { get; set; } = string.Empty;
        public int orderId { get; set; }
        public string origQty { get; set; } = string.Empty;
        public string price { get; set; } = string.Empty;
        public string side { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string stopPrice { get; set; } = string.Empty;
        public string symbol { get; set; } = string.Empty;
        public string timeInForce { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public int time { get; set; }
        public bool savedStatus { get; set; } = false;

    }
}
