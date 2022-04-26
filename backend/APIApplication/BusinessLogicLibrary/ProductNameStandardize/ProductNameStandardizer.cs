using ApiApplication.Database.Models;

namespace BusinessLogicLibrary.ProductNameStandardize;

public class ProductNameStandardizer
{
    public List<ProductStandardName> Standardize(List<Product> products)
    {
        var pList = Filter(products);
        
        var standardList = new List<ProductStandardName>();
        pList.ForEach(p =>
        {
            var psn = new ProductStandardName
            {
                Name = p.Name,
                MeasureG = (p.Measurement.ToLower().Contains("g") ? true : false),
                MeasureL = (p.Measurement.ToLower().Contains("l") ? true : false),
                MeasureStk = (p.Measurement.ToLower().Contains("stk") ? true : false),
                Organic = p.Organic
            };
            var oldPsn = FindSimilarProductStandardName(standardList, psn, p);

            psn.MeasureG |= oldPsn.MeasureG;
            psn.MeasureL |= oldPsn.MeasureL;
            psn.MeasureStk |= oldPsn.MeasureStk;
            psn.Organic |= oldPsn.Organic;

            standardList.Remove(oldPsn);
            standardList.Add(psn);
        });
        return standardList;
    }

    private List<Product> Filter(List<Product> products)
    {
        var pList = products;
        pList.ForEach(p =>
        {
            p.Name = p.Name
                .ToLower()
                .Replace("økologiske", "")
                .Replace("økologisk og laktosefri", "")
                .Replace("økologisk", "")
                .Replace("øko", "")
                .Replace("frisk dansk", "")
                .Replace("  ", " ")
                .Trim();
        });
        return pList;
    }

    private ProductStandardName FindSimilarProductStandardName(
        List<ProductStandardName> standardList, 
        ProductStandardName psn, 
        Product p)
    {
        if (standardList.Any(sn => sn.Name == p.Name))
        {
            return standardList.Find(sn => sn.Name == p.Name);
        }
        else if (standardList.Any(sn => (" " + sn.Name + " ").Contains(" " + p.Name + " ")))
        {
            return standardList.Find(sn => (" " + sn.Name + " ").Contains(" " + p.Name + " "));
        }
        else if (standardList.Any(sn => (" " + p.Name + " ").Contains(" " + sn.Name + " ")))
        {
            var oldPsn = standardList.Find(sn => (" " + p.Name + " ").Contains(" " + sn.Name + " "));
            psn.Name = oldPsn.Name;
            return oldPsn;
        }
        else
        {
            return new ProductStandardName();
        }
    }
}