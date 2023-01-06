using Newtonsoft.Json;

namespace Keyoti.GA4
{
    public class ParameterItem
    {
        [JsonProperty("item_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemId { get; set; }

        [JsonProperty("item_name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemName { get; set; }

        [JsonProperty("affiliation", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Affiliation { get; set; }

        [JsonProperty("coupon", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Coupon { get; set; }

        [JsonProperty("currency", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("discount", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Discount { get; set; }

        [JsonProperty("index", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Index { get; set; }

        [JsonProperty("item_brand", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemBrand { get; set; }

        [JsonProperty("item_category", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemCategory { get; set; }

        [JsonProperty("item_category2", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemCategory2 { get; set; }

        [JsonProperty("item_category3", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemCategory3 { get; set; }

        [JsonProperty("item_category4", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemCategory4 { get; set; }

        [JsonProperty("item_category5", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemCategory5 { get; set; }

        [JsonProperty("item_list_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemListId { get; set; }

        [JsonProperty("item_list_name", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemListName { get; set; }

        [JsonProperty("item_variant", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ItemVariant { get; set; }

        [JsonProperty("location_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LocationId { get; set; }

        [JsonProperty("price", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Price { get; set; }

        [JsonProperty("quantity", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Quantity { get; set; }
    }
}