using static System.Console;
internal class Program
{
    static void Main(string[] args)
    {
        House house = new() { Name="opera house"};

        Asset house_asset = (Asset)house;
        var opera_house=(House)house_asset;
        //WriteLine(house_asset.Name);
        //WriteLine(house.Name);
        //WriteLine(opera_house.Name);

        //WriteLine(Asset.DisplayAsset(house));
        //WriteLine(Asset.DisplayAsset(house_asset));

        // as ---> downcast otherwise null


        //
        //House? op_house = house_asset as House;
        //WriteLine($"op_house?.Name: {op_house?.Name}");

        //Asset just_ass = new Asset(){Name="ass_name"};
        //House? just_ass_house = just_ass as House;
        //WriteLine($"just_ass_house: {just_ass_house?.Name}");


        
    }
}

class Asset
{
    public required string Name;

    public static string DisplayAsset(Asset ass) => ass.Name;
}
class House : Asset 
{ 
    public string? Address;
}





