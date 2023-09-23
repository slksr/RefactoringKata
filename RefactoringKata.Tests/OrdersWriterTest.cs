using System;


namespace RefactoringKata.Tests
{
    public class OrdersWriterTest
    {
        private Orders _orders;
        private Order _order111;

        public OrdersWriterTest()
        {
            _order111 = new Order(111);
            _orders = new Orders();
            _orders.AddOrder(_order111);
        }

        [Fact]
        public void NoOrder()
        {
            Assert.Equal("{\"orders\": []}", new OrdersWriter(new Orders()).GetContents());
        }

        [Fact]
        public void OneOrder()
        {
            var order111 = "{\"id\": 111, \"products\": []}";
            Assert.Equal("{\"orders\": [" + order111 + "]}", new OrdersWriter(_orders).GetContents());
        }

        [Fact]
        public void OneOrderWithOneProduct()
        {
            _order111.AddProduct(new Product("Shirt", 1, 3, 2.99, "TWD"));

            var order111Json = JsonOrder111WithProduct("{\"code\": \"Shirt\", \"color\": \"blue\", \"size\": \"M\", \"price\": 2,99, \"currency\": \"TWD\"}");
            Assert.Equal("{\"orders\": [" + order111Json + "]}", new OrdersWriter(_orders).GetContents());
        }

        [Fact]
        public void OneOrderWithOneProductNoSize()
        {
            _order111.AddProduct(new Product("Pot", 2, -1, 16.50, "SGD"));

            var order111Json = JsonOrder111WithProduct("{\"code\": \"Pot\", \"color\": \"red\", \"price\": 16,5, \"currency\": \"SGD\"}");
            Assert.Equal("{\"orders\": [" + order111Json + "]}", new OrdersWriter(_orders).GetContents());
        }

        [Fact]
        public void TwoOrders()
        {
            _orders.AddOrder(new Order(222));

            var order111Json = JsonOrder111WithProduct("");
            var order222Json = "{\"id\": 222, \"products\": []}";
            Assert.Equal("{\"orders\": [" + order111Json + ", " + order222Json + "]}", new OrdersWriter(_orders).GetContents());
        }

        private string JsonOrder111WithProduct(string productJson)
        {
            return "{\"id\": 111, \"products\": [" + productJson + "]}";
        }
    }
}