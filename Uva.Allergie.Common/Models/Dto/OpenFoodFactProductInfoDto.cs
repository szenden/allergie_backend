
namespace Uva.Allergie.Common.Models.Dto
{
    public class OpenFoodFactProductInfoDto
    {
        public string code { get; set; }
        public int status { get; set; }
        public Product product { get; set; }
        public string status_verbose { get; set; }
    }

    public class Product
    {
        public string[] ingredients_tags { get; set; }
        public string product_name_en { get; set; }
        public int last_image_t { get; set; }
        public object[] additives_debug_tags { get; set; }
        public string lang { get; set; }
        public string[] misc_tags { get; set; }
        public int unknown_ingredients_n { get; set; }
        public object[] ingredients_from_palm_oil_tags { get; set; }
        public object[] ingredients_debug { get; set; }
        public object[] link_debug_tags { get; set; }
        public string[] additives_original_tags { get; set; }
        public string[] informers_tags { get; set; }
        public object[] unknown_nutrients_tags { get; set; }
        public object[] minerals_tags { get; set; }
        public int complete { get; set; }
        public string ingredients_text { get; set; }
        public string ingredients_text_with_allergens_en { get; set; }
        public string categories_lc { get; set; }
        public string[] countries_tags { get; set; }
        public string no_nutrition_data { get; set; }
        public string nova_group_debug { get; set; }
        public string[] last_image_dates_tags { get; set; }
        public string[] states_tags { get; set; }
        public string creator { get; set; }
        public string[] data_quality_info_tags { get; set; }
        public object[] data_quality_bugs_tags { get; set; }
        public Selected_Images selected_images { get; set; }
        public string image_nutrition_thumb_url { get; set; }
        public string categories { get; set; }
        public string ingredients_text_with_allergens { get; set; }
        public object[] allergens_hierarchy { get; set; }
        public object[] amino_acids_tags { get; set; }
        public string packaging { get; set; }
        public string id { get; set; }
        public Ingredient[] ingredients { get; set; }
        public object[] nucleotides_tags { get; set; }
        public string[] categories_tags { get; set; }
        public string image_small_url { get; set; }
        public string image_url { get; set; }
        public object[] origins_tags { get; set; }
        public int ingredients_that_may_be_from_palm_oil_n { get; set; }
        public int nova_group { get; set; }
        public int ingredients_n { get; set; }
        public string[] ingredients_analysis_tags { get; set; }
        public string[] correctors_tags { get; set; }
        public string[] packaging_tags { get; set; }
        public object[] allergens_tags { get; set; }
        public object[] nucleotides_prev_tags { get; set; }
        public object[] other_nutritional_substances_tags { get; set; }
        public string pnns_groups_2 { get; set; }
        public string[] states_hierarchy { get; set; }
        public string ingredients_text_en { get; set; }
        public int nutrition_score_beverage { get; set; }
        public string code { get; set; }
        public string[] popularity_tags { get; set; }
        public string nova_groups { get; set; }
        public Languages languages { get; set; }
        public object[] additives_old_tags { get; set; }
        public string image_nutrition_url { get; set; }
        public int ingredients_from_or_that_may_be_from_palm_oil_n { get; set; }
        public object[] emb_codes_debug_tags { get; set; }
        public string[] nutrition_grades_tags { get; set; }
        public string image_ingredients_thumb_url { get; set; }
        public string states { get; set; }
        public string emb_codes { get; set; }
        public string max_imgid { get; set; }
        public object[] countries_debug_tags { get; set; }
        public string image_ingredients_small_url { get; set; }
        public string last_editor { get; set; }
        public int ingredients_from_palm_oil_n { get; set; }
        public string interface_version_modified { get; set; }
        public string[] languages_hierarchy { get; set; }
        public string[] ingredients_n_tags { get; set; }
        public string[] data_quality_warnings_tags { get; set; }
        public string[] _keywords { get; set; }
        public object[] ingredients_that_may_be_from_palm_oil_tags { get; set; }
        public object[] traces_tags { get; set; }
        public string serving_quantity { get; set; }
        public string[] nova_groups_tags { get; set; }
        public object[] traces_hierarchy { get; set; }
        public string brands { get; set; }
        public string countries { get; set; }
        public object[] serving_size_debug_tags { get; set; }
        public string serving_size { get; set; }
        public string nutriscore_grade { get; set; }
        public int nutrition_score_warning_no_fruits_vegetables_nuts { get; set; }
        public object[] origins_debug_tags { get; set; }
        public string stores { get; set; }
        public int nutrition_score_warning_no_fiber { get; set; }
        public string product_name { get; set; }
        public string nutrition_score_debug { get; set; }
        public string[] countries_hierarchy { get; set; }
        public object[] cities_tags { get; set; }
        public string[] nutrient_levels_tags { get; set; }
        public string last_modified_by { get; set; }
        public object[] vitamins_tags { get; set; }
        public string[] categories_hierarchy { get; set; }
        public string[] photographers_tags { get; set; }
        public int additives_old_n { get; set; }
        public string countries_lc { get; set; }
        public int created_t { get; set; }
        public string traces_from_user { get; set; }
        public string image_front_url { get; set; }
        public long sortkey { get; set; }
        public string interface_version_created { get; set; }
        public float completeness { get; set; }
        public string product_name_fr { get; set; }
        public object[] vitamins_prev_tags { get; set; }
        public object[] product_name_en_debug_tags { get; set; }
        public string compared_to_category { get; set; }
        public string nutrition_grades { get; set; }
        public string nutrition_data_per { get; set; }
        public object[] packaging_debug_tags { get; set; }
        public string image_front_thumb_url { get; set; }
        public object[] data_quality_errors_tags { get; set; }
        public string traces { get; set; }
        public string traces_from_ingredients { get; set; }
        public object[] additives_prev_original_tags { get; set; }
        public object[] traces_debug_tags { get; set; }
        public object[] checkers_tags { get; set; }
        public object[] quantity_debug_tags { get; set; }
        public string[] labels_tags { get; set; }
        public object[] purchase_places_tags { get; set; }
        public string[] data_quality_tags { get; set; }
        public string[] pnns_groups_2_tags { get; set; }
        public object[] amino_acids_prev_tags { get; set; }
        public int scans_n { get; set; }
        public string[] labels_hierarchy { get; set; }
        public object[] ingredients_ids_debug { get; set; }
        public string[] nova_group_tags { get; set; }
        public string countries_beforescanbot { get; set; }
        public string link { get; set; }
        public Images images { get; set; }
        public int unique_scans_n { get; set; }
        public Nutrient_Levels nutrient_levels { get; set; }
        public object[] stores_tags { get; set; }
        public string[] ingredients_hierarchy { get; set; }
        public string image_nutrition_small_url { get; set; }
        public object[] manufacturing_places_debug_tags { get; set; }
        public string labels_lc { get; set; }
        public string image_front_small_url { get; set; }
        public string[] data_sources_tags { get; set; }
        public Nutriscore_Data nutriscore_data { get; set; }
        public string[] pnns_groups_1_tags { get; set; }
        public string image_ingredients_url { get; set; }
        public object[] purchase_places_debug_tags { get; set; }
        public string[] brands_tags { get; set; }
        public string[] ingredients_original_tags { get; set; }
        public string ingredients_text_debug { get; set; }
        public int rev { get; set; }
        public string[] languages_tags { get; set; }
        public string labels { get; set; }
        public string purchase_places { get; set; }
        public string lc { get; set; }
        public string image_thumb_url { get; set; }
        public string update_key { get; set; }
        public string allergens { get; set; }
        public string[] codes_tags { get; set; }
        public Nutriments nutriments { get; set; }
        public object[] minerals_prev_tags { get; set; }
        public string nutrition_grade_fr { get; set; }
        public string quantity { get; set; }
        public string allergens_from_ingredients { get; set; }
        public Languages_Codes languages_codes { get; set; }
        public string manufacturing_places { get; set; }
        public int with_sweeteners { get; set; }
        public object[] stores_debug_tags { get; set; }
        public string product_quantity { get; set; }
        public int completed_t { get; set; }
        public int nutriscore_score { get; set; }
        public string nutrition_data_prepared_per { get; set; }
        public string allergens_from_user { get; set; }
        public object[] manufacturing_places_tags { get; set; }
        public string[] editors_tags { get; set; }
        public string _id { get; set; }
        public string[] additives_tags { get; set; }
        public int additives_n { get; set; }
        public string[] last_edit_dates_tags { get; set; }
        public int last_modified_t { get; set; }
        public object[] emb_codes_tags { get; set; }
        public string pnns_groups_1 { get; set; }
        public string[] entry_dates_tags { get; set; }
        public string origins { get; set; }
        public object ingredients_text_with_allergens_fr { get; set; }
        public string data_sources { get; set; }
    }

    public class Selected_Images
    {
        public Nutrition nutrition { get; set; }
        public Front front { get; set; }
        public Ingredients ingredients { get; set; }
    }

    public class Nutrition
    {
        public Small small { get; set; }
        public Thumb thumb { get; set; }
        public Display display { get; set; }
    }

    public class Small
    {
        public string en { get; set; }
    }

    public class Thumb
    {
        public string en { get; set; }
    }

    public class Display
    {
        public string en { get; set; }
    }

    public class Front
    {
        public Display1 display { get; set; }
        public Thumb1 thumb { get; set; }
        public Small1 small { get; set; }
    }

    public class Display1
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Thumb1
    {
        public string fr { get; set; }
        public string en { get; set; }
    }

    public class Small1
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Ingredients
    {
        public Display2 display { get; set; }
        public Small2 small { get; set; }
        public Thumb2 thumb { get; set; }
    }

    public class Display2
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Small2
    {
        public string en { get; set; }
        public string fr { get; set; }
    }

    public class Thumb2
    {
        public string fr { get; set; }
        public string en { get; set; }
    }

    public class Languages
    {
        public int enenglish { get; set; }
        public int enfrench { get; set; }
    }

    public class Images
    {
        public _2 _2 { get; set; }
        public Ingredients_En ingredients_en { get; set; }
        public _6 _6 { get; set; }
        public _8 _8 { get; set; }
        public Front_En front_en { get; set; }
        public _1 _1 { get; set; }
        public Ingredients_Fr ingredients_fr { get; set; }
        public Nutrition_En nutrition_en { get; set; }
        public _3 _3 { get; set; }
        public _7 _7 { get; set; }
        public Front_Fr front_fr { get; set; }
        public _4 _4 { get; set; }
        public _9 _9 { get; set; }
        public _5 _5 { get; set; }
        public _10 _10 { get; set; }
    }

    public class _2
    {
        public string uploader { get; set; }
        public Sizes sizes { get; set; }
        public int uploaded_t { get; set; }
    }

    public class Sizes
    {
        public _100 _100 { get; set; }
        public Full full { get; set; }
        public _400 _400 { get; set; }
    }

    public class _100
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _400
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Ingredients_En
    {
        public object white_magic { get; set; }
        public string rev { get; set; }
        public object normalize { get; set; }
        public object y1 { get; set; }
        public string imgid { get; set; }
        public string geometry { get; set; }
        public Sizes1 sizes { get; set; }
        public object angle { get; set; }
        public object x1 { get; set; }
        public object x2 { get; set; }
        public object y2 { get; set; }
    }

    public class Sizes1
    {
        public _1001 _100 { get; set; }
        public _200 _200 { get; set; }
        public Full1 full { get; set; }
        public _4001 _400 { get; set; }
    }

    public class _1001
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _200
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full1
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _4001
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _6
    {
        public int uploaded_t { get; set; }
        public string uploader { get; set; }
        public Sizes2 sizes { get; set; }
    }

    public class Sizes2
    {
        public Full2 full { get; set; }
        public _4002 _400 { get; set; }
        public _1002 _100 { get; set; }
    }

    public class Full2
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _4002
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _1002
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _8
    {
        public Sizes3 sizes { get; set; }
        public string uploader { get; set; }
        public int uploaded_t { get; set; }
    }

    public class Sizes3
    {
        public _4003 _400 { get; set; }
        public Full3 full { get; set; }
        public _1003 _100 { get; set; }
    }

    public class _4003
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full3
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1003
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Front_En
    {
        public string y2 { get; set; }
        public string x2 { get; set; }
        public string rev { get; set; }
        public object white_magic { get; set; }
        public string y1 { get; set; }
        public object normalize { get; set; }
        public string imgid { get; set; }
        public string geometry { get; set; }
        public Sizes4 sizes { get; set; }
        public int angle { get; set; }
        public string x1 { get; set; }
    }

    public class Sizes4
    {
        public _2001 _200 { get; set; }
        public Full4 full { get; set; }
        public _4004 _400 { get; set; }
        public _1004 _100 { get; set; }
    }

    public class _2001
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Full4
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _4004
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1004
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1
    {
        public Sizes5 sizes { get; set; }
        public string uploader { get; set; }
        public int uploaded_t { get; set; }
    }

    public class Sizes5
    {
        public _4005 _400 { get; set; }
        public Full5 full { get; set; }
        public _1005 _100 { get; set; }
    }

    public class _4005
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full5
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1005
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Ingredients_Fr
    {
        public object x2 { get; set; }
        public string geometry { get; set; }
        public Sizes6 sizes { get; set; }
        public object angle { get; set; }
        public object x1 { get; set; }
        public string white_magic { get; set; }
        public string rev { get; set; }
        public object y1 { get; set; }
        public string imgid { get; set; }
        public string normalize { get; set; }
        public int ocr { get; set; }
        public object y2 { get; set; }
        public string orientation { get; set; }
    }

    public class Sizes6
    {
        public _2002 _200 { get; set; }
        public _4006 _400 { get; set; }
        public Full6 full { get; set; }
        public _1006 _100 { get; set; }
    }

    public class _2002
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _4006
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full6
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1006
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Nutrition_En
    {
        public string y2 { get; set; }
        public string x2 { get; set; }
        public object white_magic { get; set; }
        public string rev { get; set; }
        public string imgid { get; set; }
        public string y1 { get; set; }
        public object normalize { get; set; }
        public Sizes7 sizes { get; set; }
        public string geometry { get; set; }
        public string x1 { get; set; }
        public int angle { get; set; }
    }

    public class Sizes7
    {
        public _1007 _100 { get; set; }
        public Full7 full { get; set; }
        public _4007 _400 { get; set; }
        public _2003 _200 { get; set; }
    }

    public class _1007
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Full7
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _4007
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _2003
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _3
    {
        public int uploaded_t { get; set; }
        public Sizes8 sizes { get; set; }
        public string uploader { get; set; }
    }

    public class Sizes8
    {
        public Full8 full { get; set; }
        public _4008 _400 { get; set; }
        public _1008 _100 { get; set; }
    }

    public class Full8
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _4008
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _1008
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _7
    {
        public int uploaded_t { get; set; }
        public Sizes9 sizes { get; set; }
        public string uploader { get; set; }
    }

    public class Sizes9
    {
        public _1009 _100 { get; set; }
        public _4009 _400 { get; set; }
        public Full9 full { get; set; }
    }

    public class _1009
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _4009
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Full9
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Front_Fr
    {
        public string imgid { get; set; }
        public string normalize { get; set; }
        public object y1 { get; set; }
        public string rev { get; set; }
        public string white_magic { get; set; }
        public object angle { get; set; }
        public object x1 { get; set; }
        public string geometry { get; set; }
        public Sizes10 sizes { get; set; }
        public object x2 { get; set; }
        public object y2 { get; set; }
    }

    public class Sizes10
    {
        public _10010 _100 { get; set; }
        public _2004 _200 { get; set; }
        public Full10 full { get; set; }
        public _40010 _400 { get; set; }
    }

    public class _10010
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _2004
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Full10
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _40010
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _4
    {
        public Sizes11 sizes { get; set; }
        public string uploader { get; set; }
        public int uploaded_t { get; set; }
    }

    public class Sizes11
    {
        public _40011 _400 { get; set; }
        public Full11 full { get; set; }
        public _10011 _100 { get; set; }
    }

    public class _40011
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Full11
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _10011
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _9
    {
        public int uploaded_t { get; set; }
        public Sizes12 sizes { get; set; }
        public string uploader { get; set; }
    }

    public class Sizes12
    {
        public _40012 _400 { get; set; }
        public Full12 full { get; set; }
        public _10012 _100 { get; set; }
    }

    public class _40012
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full12
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _10012
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _5
    {
        public int uploaded_t { get; set; }
        public string uploader { get; set; }
        public Sizes13 sizes { get; set; }
    }

    public class Sizes13
    {
        public _10013 _100 { get; set; }
        public _40013 _400 { get; set; }
        public Full13 full { get; set; }
    }

    public class _10013
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _40013
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class Full13
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class _10
    {
        public Sizes14 sizes { get; set; }
        public string uploader { get; set; }
        public int uploaded_t { get; set; }
    }

    public class Sizes14
    {
        public Full14 full { get; set; }
        public _40014 _400 { get; set; }
        public _10014 _100 { get; set; }
    }

    public class Full14
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _40014
    {
        public int w { get; set; }
        public int h { get; set; }
    }

    public class _10014
    {
        public int h { get; set; }
        public int w { get; set; }
    }

    public class Nutrient_Levels
    {
        public string sugars { get; set; }
        public string fat { get; set; }
        public string saturatedfat { get; set; }
        public string salt { get; set; }
    }

    public class Nutriscore_Data
    {
        public int fruits_vegetables_nuts_colza_walnut_olive_oils_points { get; set; }
        public int energy_value { get; set; }
        public float sugars_value { get; set; }
        public int sodium_points { get; set; }
        public int fiber { get; set; }
        public int is_water { get; set; }
        public int saturated_fat_value { get; set; }
        public int proteins_points { get; set; }
        public int sodium_value { get; set; }
        public int saturated_fat { get; set; }
        public int energy_points { get; set; }
        public int saturated_fat_ratio_value { get; set; }
        public int fiber_value { get; set; }
        public int score { get; set; }
        public int is_cheese { get; set; }
        public int fruits_vegetables_nuts_colza_walnut_olive_oils { get; set; }
        public int fiber_points { get; set; }
        public float sugars { get; set; }
        public int energy { get; set; }
        public int saturated_fat_points { get; set; }
        public string grade { get; set; }
        public int fruits_vegetables_nuts_colza_walnut_olive_oils_value { get; set; }
        public int saturated_fat_ratio { get; set; }
        public int is_beverage { get; set; }
        public int proteins { get; set; }
        public int sugars_points { get; set; }
        public int is_fat { get; set; }
        public int saturated_fat_ratio_points { get; set; }
        public int proteins_value { get; set; }
        public int positive_points { get; set; }
        public int sodium { get; set; }
        public int negative_points { get; set; }
    }

    public class Nutriments
    {
        public int salt_serving { get; set; }
        public string energykcal_unit { get; set; }
        public int nutritionscoreuk { get; set; }
        public string sodium_unit { get; set; }
        public int saturatedfat { get; set; }
        public string carbohydrates_unit { get; set; }
        public int energykcal { get; set; }
        public int energy_value { get; set; }
        public string sugars_unit { get; set; }
        public float sugars_value { get; set; }
        public int nutritionscorefr_100g { get; set; }
        public int fat_value { get; set; }
        public float carbohydrates { get; set; }
        public float carbohydrates_serving { get; set; }
        public string proteins_unit { get; set; }
        public string saturatedfat_unit { get; set; }
        public int energykcal_serving { get; set; }
        public int novagroup_serving { get; set; }
        public int proteins_100g { get; set; }
        public int saturatedfat_serving { get; set; }
        public float sugars_100g { get; set; }
        public int energy_100g { get; set; }
        public int fat_serving { get; set; }
        public float sugars_serving { get; set; }
        public int nutritionscoreuk_100g { get; set; }
        public int sodium_value { get; set; }
        public int sodium_100g { get; set; }
        public int energy { get; set; }
        public string salt_unit { get; set; }
        public int fat { get; set; }
        public string fat_unit { get; set; }
        public int energykcal_100g { get; set; }
        public float carbohydrates_value { get; set; }
        public float sugars { get; set; }
        public int saturatedfat_100g { get; set; }
        public int salt_value { get; set; }
        public int energy_serving { get; set; }
        public int proteins_serving { get; set; }
        public int nutritionscorefr { get; set; }
        public int salt_100g { get; set; }
        public int novagroup_100g { get; set; }
        public int proteins_value { get; set; }
        public int saturatedfat_value { get; set; }
        public int energykcal_value { get; set; }
        public float carbohydrates_100g { get; set; }
        public string energy_unit { get; set; }
        public int sodium { get; set; }
        public int salt { get; set; }
        public int proteins { get; set; }
        public int fat_100g { get; set; }
        public int sodium_serving { get; set; }
        public int novagroup { get; set; }
    }

    public class Languages_Codes
    {
        public int en { get; set; }
        public int fr { get; set; }
    }

    public class Ingredient
    {
        public string vegetarian { get; set; }
        public string vegan { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        public int rank { get; set; }
        public string percent { get; set; }
        public string has_sub_ingredients { get; set; }
    }

}
