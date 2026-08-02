using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, PaymentInterfacesApp!");

        Checkout(new StripePayment());
        Checkout(new GooglePayment());
        Checkout(new PaypalPayment());
    }
    static void Checkout(IPayment payment)
    {
        payment.Pay();
    }
}

class StripePayment : IPayment
{
    public void Pay()
    {
        WriteLine("Stripe payment...");
    }
}
class PaypalPayment : IPayment
{
    public void Pay()
    {
        WriteLine("Paypal payment...");
    }
}

class GooglePayment : IPayment
{
    public void Pay()
    {
        WriteLine("Google payment...");
    }
}


interface IPayment
{
    void Pay();
}