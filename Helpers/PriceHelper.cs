namespace dotnet.Helpers;

public static class PriceHelper
{
    public static Price CalculateMissing(Price price)
    {
        if (price.Net != null) {
            price.Gross = GrossFromNet((decimal)price.Net, price.Rate);
            price.VAT = VATFromNet((decimal)price.Net, price.Rate);
        } else if (price.Gross != null) {
            price.Net = NetFromGross((decimal)price.Gross, price.Rate);
            price.VAT = VATFromGross((decimal)price.Gross, price.Rate);
        } else if (price.VAT != null) {
            price.Gross = GrossFromVAT((decimal)price.VAT, price.Rate);
            price.Net = NetFromVAT((decimal)price.VAT, price.Rate);
        }

        return price;
    }

    private static decimal GrossFromNet(decimal net, decimal rate)
    {
        return net + net * rate;
    }

    private static decimal NetFromGross(decimal gross, decimal rate)
    {
        return gross / (1 + rate);
    }

    private static decimal VATFromNet(decimal net, decimal rate)
    {
        return net * rate;
    }

    private static decimal NetFromVAT(decimal vat, decimal rate)
    {
        return vat / rate;
    }

    private static decimal GrossFromVAT(decimal vat, decimal rate)
    {
        return vat + vat / rate;
    }

    private static decimal VATFromGross(decimal gross, decimal rate)
    {
        return gross - gross / (1 + rate);
    }
}
