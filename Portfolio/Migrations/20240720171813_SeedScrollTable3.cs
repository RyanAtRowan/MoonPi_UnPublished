using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class SeedScrollTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Scrolls",
                columns: new[] { "Id", "Name", "Price", "Slot", "Stat", "Success" },
                values: new object[,]
                {
                    { 1, "Scroll for Helmet for DEF 10%", 0, "helmet", "DEF", 10 },
                    { 2, "Scroll for Helmet for DEF 60%", 0, "helmet", "DEF", 60 },
                    { 3, "Scroll for Helmet for DEF 100%", 0, "helmet", "DEF", 100 },
                    { 4, "Dark Scroll for Helmet for DEF 30%", 0, "helmet", "DEF", 30 },
                    { 5, "Dark Scroll for Helmet for DEF 70%", 0, "helmet", "DEF", 70 },
                    { 6, "Scroll for Helmet for HP 10%", 0, "helmet", "HP", 10 },
                    { 7, "Scroll for Helmet for HP 60%", 0, "helmet", "HP", 60 },
                    { 8, "Scroll for Helmet for HP 100%", 0, "helmet", "HP", 100 },
                    { 9, "Dark Scroll for Helmet for HP 30%", 0, "helmet", "HP", 30 },
                    { 10, "Dark Scroll for Helmet for HP 70%", 0, "helmet", "HP", 70 },
                    { 11, "Scroll for Helmet for INT 10%", 0, "helmet", "INT", 10 },
                    { 12, "Scroll for Helmet for INT 60%", 0, "helmet", "INT", 60 },
                    { 13, "Scroll for Helmet for INT 100%", 0, "helmet", "INT", 100 },
                    { 14, "Dark Scroll for Helmet for INT 30%", 0, "helmet", "INT", 30 },
                    { 15, "Dark Scroll for Helmet for INT 70%", 0, "helmet", "INT", 70 },
                    { 16, "Scroll for Helmet for Accuracy 10%", 0, "helmet", "ACC", 10 },
                    { 17, "Scroll for Helmet for Accuracy 60%", 0, "helmet", "ACC", 60 },
                    { 18, "Scroll for Helmet for Accuracy 100%", 0, "helmet", "ACC", 100 },
                    { 19, "Dark Scroll for Helmet for Accuracy 30%", 0, "helmet", "ACC", 30 },
                    { 20, "Dark Scroll for Helmet for Accuracy 70%", 0, "helmet", "ACC", 70 },
                    { 21, "Scroll for Helmet for DEX 10%", 0, "helmet", "DEX", 10 },
                    { 22, "Scroll for Helmet for DEX 60%", 0, "helmet", "DEX", 60 },
                    { 23, "Scroll for Helmet for DEX 100%", 0, "helmet", "DEX", 100 },
                    { 24, "Dark Scroll for Helmet for DEX 30%", 0, "helmet", "DEX", 30 },
                    { 25, "Dark Scroll for Helmet for DEX 70%", 0, "helmet", "DEX", 70 },
                    { 26, "Scroll for Face Accessory for HP 10%", 0, "face", "HP", 10 },
                    { 27, "Scroll for Face Accessory for HP 60%", 0, "face", "HP", 60 },
                    { 28, "Scroll for Face Accessory for HP 100%", 0, "face", "HP", 100 },
                    { 29, "Dark Scroll for Face Accessory for HP 30%", 0, "face", "HP", 30 },
                    { 30, "Dark Scroll for Face Accessory for HP 70%", 0, "face", "HP", 70 },
                    { 31, "Scroll for Face Accessory for Avoidability 10%", 0, "face", "AVOID", 10 },
                    { 32, "Scroll for Face Accessory for Avoidability 60%", 0, "face", "AVOID", 60 },
                    { 33, "Scroll for Face Accessory for Avoidability 100%", 0, "face", "AVOID", 100 },
                    { 34, "Dark Scroll for Face Accessory for Avoidability 30%", 0, "face", "AVOID", 30 },
                    { 35, "Dark Scroll for Face Accessory for Avoidability 70%", 0, "face", "AVOID", 70 },
                    { 36, "Scroll for Eye Accessory for Accuracy 10%", 0, "eye", "ACC", 10 },
                    { 37, "Scroll for Eye Accessory for Accuracy 60%", 0, "eye", "ACC", 60 },
                    { 38, "Scroll for Eye Accessory for Accuracy 100%", 0, "eye", "ACC", 100 },
                    { 39, "Dark Scroll for Eye Accessory for Accuracy 30%", 0, "eye", "ACC", 30 },
                    { 40, "Dark Scroll for Eye Accessory for Accuracy 70%", 0, "eye", "ACC", 70 },
                    { 41, "Scroll for Eye Accessory for HP 10%", 0, "eye", "HP", 10 },
                    { 42, "Scroll for Eye Accessory for HP 60%", 0, "eye", "HP", 60 },
                    { 43, "Scroll for Eye Accessory for HP 100%", 0, "eye", "HP", 100 },
                    { 44, "Dark Scroll for Eye Accessory for HP 30%", 0, "eye", "HP", 30 },
                    { 45, "Dark Scroll for Eye Accessory for HP 70%", 0, "eye", "HP", 70 },
                    { 46, "Scroll for Earring for INT 10%", 0, "earring", "INT", 10 },
                    { 47, "Scroll for Earring for INT 60%", 0, "earring", "INT", 60 },
                    { 48, "Scroll for Earring for INT 100%", 0, "earring", "INT", 100 },
                    { 49, "Dark Scroll for Earring for INT 30%", 0, "earring", "INT", 30 },
                    { 50, "Dark Scroll for Earring for INT 70%", 0, "earring", "INT", 70 },
                    { 51, "Scroll for Earring for DEX 10%", 0, "earring", "DEX", 10 },
                    { 52, "Scroll for Earring for DEX 60%", 0, "earring", "DEX", 60 },
                    { 53, "Scroll for Earring for DEX 100%", 0, "earring", "DEX", 100 },
                    { 54, "Dark Scroll for Earring for DEX 30%", 0, "earring", "DEX", 30 },
                    { 55, "Dark Scroll for Earring for DEX 70%", 0, "earring", "DEX", 70 },
                    { 56, "Scroll for Earrings for DEF 10%", 0, "earring", "DEF", 10 },
                    { 57, "Scroll for Earrings for DEF 60%", 0, "earring", "DEF", 60 },
                    { 58, "Scroll for Earrings for DEF 100%", 0, "earring", "DEF", 100 },
                    { 59, "Dark Scroll for Earrings for DEF 30%", 0, "earring", "DEF", 30 },
                    { 60, "Dark Scroll for Earrings for DEF 70%", 0, "earring", "DEF", 70 },
                    { 61, "Scroll for Earring for LUK 10%", 0, "earring", "LUK", 10 },
                    { 62, "Scroll for Earring for LUK 60%", 0, "earring", "LUK", 60 },
                    { 63, "Scroll for Earring for LUK 100%", 0, "earring", "LUK", 100 },
                    { 64, "Dark Scroll for Earring for LUK 30%", 0, "earring", "LUK", 30 },
                    { 65, "Dark Scroll for Earring for LUK 70%", 0, "earring", "LUK", 70 },
                    { 66, "Scroll for Earring for HP 10%", 0, "earring", "HP", 10 },
                    { 67, "Scroll for Earring for HP 60%", 0, "earring", "HP", 60 },
                    { 68, "Scroll for Earring for HP 100%", 0, "earring", "HP", 100 },
                    { 69, "Dark Scroll for Earring for HP 30%", 0, "earring", "HP", 30 },
                    { 70, "Dark Scroll for Earring for HP 70%", 0, "earring", "HP", 70 },
                    { 71, "Scroll for Topwear for DEF 10%", 0, "top", "DEF", 10 },
                    { 72, "Scroll for Topwear for DEF 60%", 0, "top", "DEF", 60 },
                    { 73, "Scroll for Topwear for DEF 100%", 0, "top", "DEF", 100 },
                    { 74, "Dark Scroll for Topwear for DEF 30%", 0, "top", "DEF", 30 },
                    { 75, "Dark Scroll for Topwear for DEF 70%", 0, "top", "DEF", 70 },
                    { 76, "Scroll for Topwear for STR 10%", 0, "top", "STR", 10 },
                    { 77, "Scroll for Topwear for STR 60%", 0, "top", "STR", 60 },
                    { 78, "Scroll for Topwear for STR 100%", 0, "top", "STR", 100 },
                    { 79, "Dark Scroll for Topwear for STR 30%", 0, "top", "STR", 30 },
                    { 80, "Dark Scroll for Topwear for STR 70%", 0, "top", "STR", 70 },
                    { 81, "Scroll for Topwear for HP 10%", 0, "top", "HP", 10 },
                    { 82, "Scroll for Topwear for HP 60%", 0, "top", "HP", 60 },
                    { 83, "Scroll for Topwear for HP 100%", 0, "top", "HP", 100 },
                    { 84, "Dark Scroll for Topwear for HP 30%", 0, "top", "HP", 30 },
                    { 85, "Dark Scroll for Topwear for HP 70%", 0, "top", "HP", 70 },
                    { 86, "Scroll for Topwear for LUK 10%", 0, "top", "LUK", 10 },
                    { 87, "Scroll for Topwear for LUK 60%", 0, "top", "LUK", 60 },
                    { 88, "Scroll for Topwear for LUK 100%", 0, "top", "LUK", 100 },
                    { 89, "Dark Scroll for Topwear for LUK 30%", 0, "top", "LUK", 30 },
                    { 90, "Dark Scroll for Topwear for LUK 70%", 0, "top", "LUK", 70 },
                    { 91, "Scroll for Overall Armor for DEX 10%", 0, "overall", "DEX", 10 },
                    { 92, "Scroll for Overall Armor for DEX 60%", 0, "overall", "DEX", 60 },
                    { 93, "Scroll for Overall Armor for DEX 100%", 0, "overall", "DEX", 100 },
                    { 94, "Dark Scroll for Overall Armor for DEX 30%", 0, "overall", "DEX", 30 },
                    { 95, "Dark Scroll for Overall Armor for DEX 70%", 0, "overall", "DEX", 70 },
                    { 96, "Scroll for Overall Armor for DEF 10%", 0, "overall", "DEF", 10 },
                    { 97, "Scroll for Overall Armor for DEF 60%", 0, "overall", "DEF", 60 },
                    { 98, "Scroll for Overall Armor for DEF 100%", 0, "overall", "DEF", 100 },
                    { 99, "Dark Scroll for Overall Armor for DEF 30%", 0, "overall", "DEF", 30 },
                    { 100, "Dark Scroll for Overall Armor for DEF 70%", 0, "overall", "DEF", 70 },
                    { 101, "Scroll for Overall Armor for INT 10%", 0, "overall", "INT", 10 },
                    { 102, "Scroll for Overall Armor for INT 60%", 0, "overall", "INT", 60 },
                    { 103, "Scroll for Overall Armor for INT 100%", 0, "overall", "INT", 100 },
                    { 104, "Dark Scroll for Overall Armor for INT 30%", 0, "overall", "INT", 30 },
                    { 105, "Dark Scroll for Overall Armor for INT 70%", 0, "overall", "INT", 70 },
                    { 106, "Scroll for Overall Armor for LUK 10%", 0, "overall", "LUK", 10 },
                    { 107, "Scroll for Overall Armor for LUK 60%", 0, "overall", "LUK", 60 },
                    { 108, "Scroll for Overall Armor for LUK 100%", 0, "overall", "LUK", 100 },
                    { 109, "Dark Scroll for Overall Armor for LUK 30%", 0, "overall", "LUK", 30 },
                    { 110, "Dark Scroll for Overall Armor for LUK 70%", 0, "overall", "LUK", 70 },
                    { 111, "Scroll for Overall Armor for STR 10%", 0, "overall", "STR", 10 },
                    { 112, "Scroll for Overall Armor for STR 60%", 0, "overall", "STR", 60 },
                    { 113, "Scroll for Overall Armor for STR 100%", 0, "overall", "STR", 100 },
                    { 114, "Dark Scroll for Overall Armor for STR 30%", 0, "overall", "STR", 30 },
                    { 115, "Dark Scroll for Overall Armor for STR 70%", 0, "overall", "STR", 70 },
                    { 116, "Scroll for Bottomwear for DEF 10%", 0, "bottom", "DEF", 10 },
                    { 117, "Scroll for Bottomwear for DEF 60%", 0, "bottom", "DEF", 60 },
                    { 118, "Scroll for Bottomwear for DEF 100%", 0, "bottom", "DEF", 100 },
                    { 119, "Dark Scroll for Bottomwear for DEF 30%", 0, "bottom", "DEF", 30 },
                    { 120, "Dark Scroll for Bottomwear for DEF 70%", 0, "bottom", "DEF", 70 },
                    { 121, "Scroll for Bottomwear for Jump 10%", 0, "bottom", "JUMP", 10 },
                    { 122, "Scroll for Bottomwear for Jump 60%", 0, "bottom", "JUMP", 60 },
                    { 123, "Scroll for Bottomwear for Jump 100%", 0, "bottom", "JUMP", 100 },
                    { 124, "Dark Scroll for Bottomwear for Jump 30%", 0, "bottom", "JUMP", 30 },
                    { 125, "Dark Scroll for Bottomwear for Jump 70%", 0, "bottom", "JUMP", 70 },
                    { 126, "Scroll for Bottomwear for HP 10%", 0, "bottom", "HP", 10 },
                    { 127, "Scroll for Bottomwear for HP 60%", 0, "bottom", "HP", 60 },
                    { 128, "Scroll for Bottomwear for HP 100%", 0, "bottom", "HP", 100 },
                    { 129, "Dark Scroll for Bottomwear for HP 30%", 0, "bottom", "HP", 30 },
                    { 130, "Dark Scroll for Bottomwear for HP 70%", 0, "bottom", "HP", 70 },
                    { 131, "Scroll for Bottomwear for DEX 10%", 0, "bottom", "DEX", 10 },
                    { 132, "Scroll for Bottomwear for DEX 60%", 0, "bottom", "DEX", 60 },
                    { 133, "Scroll for Bottomwear for DEX 100%", 0, "bottom", "DEX", 100 },
                    { 134, "Dark Scroll for Bottomwear for DEX 30%", 0, "bottom", "DEX", 30 },
                    { 135, "Dark Scroll for Bottomwear for DEX 70%", 0, "bottom", "DEX", 70 },
                    { 136, "Scroll for Shoes for Avoidability 10%", 0, "shoes", "AVOID", 10 },
                    { 137, "Scroll for Shoes for Avoidability 60%", 0, "shoes", "AVOID", 60 },
                    { 138, "Scroll for Shoes for Avoidability 100%", 0, "shoes", "AVOID", 100 },
                    { 139, "Dark Scroll for Shoes for Avoidability 30%", 0, "shoes", "AVOID", 30 },
                    { 140, "Dark Scroll for Shoes for Avoidability 70%", 0, "shoes", "AVOID", 70 },
                    { 141, "Scroll for Shoes for Jump 10%", 0, "shoes", "JUMP", 10 },
                    { 142, "Scroll for Shoes for Jump 60%", 0, "shoes", "JUMP", 60 },
                    { 143, "Scroll for Shoes for Jump 100%", 0, "shoes", "JUMP", 100 },
                    { 144, "Dark Scroll for Shoes for Jump 30%", 0, "shoes", "JUMP", 30 },
                    { 145, "Dark Scroll for Shoes for Jump 70%", 0, "shoes", "JUMP", 70 },
                    { 146, "Scroll for Shoes for Speed 10%", 0, "shoes", "SPEED", 10 },
                    { 147, "Scroll for Shoes for Speed 60%", 0, "shoes", "SPEED", 60 },
                    { 148, "Scroll for Shoes for Speed 100%", 0, "shoes", "SPEED", 100 },
                    { 149, "Dark Scroll for Shoes for Speed 30%", 0, "shoes", "SPEED", 30 },
                    { 150, "Dark Scroll for Shoes for Speed 70%", 0, "shoes", "SPEED", 70 },
                    { 151, "Scroll for Gloves for DEX 10%", 0, "gloves", "DEX", 10 },
                    { 152, "Scroll for Gloves for DEX 60%", 0, "gloves", "DEX", 60 },
                    { 153, "Scroll for Gloves for DEX 100%", 0, "gloves", "DEX", 100 },
                    { 154, "Dark Scroll for Gloves for DEX 30%", 0, "gloves", "DEX", 30 },
                    { 155, "Dark Scroll for Gloves for DEX 70%", 0, "gloves", "DEX", 70 },
                    { 156, "Scroll for Gloves for ATT 10%", 0, "gloves", "ATT", 10 },
                    { 157, "Scroll for Gloves for ATT 60%", 0, "gloves", "ATT", 60 },
                    { 158, "Scroll for Gloves for ATT 100%", 0, "gloves", "ATT", 100 },
                    { 159, "Dark Scroll for Gloves for ATT 30%", 0, "gloves", "ATT", 30 },
                    { 160, "Dark Scroll for Gloves for ATT 70%", 0, "gloves", "ATT", 70 },
                    { 161, "Scroll for Gloves for HP 10%", 0, "gloves", "HP", 10 },
                    { 162, "Scroll for Gloves for HP 60%", 0, "gloves", "HP", 60 },
                    { 163, "Scroll for Gloves for HP 100%", 0, "gloves", "HP", 100 },
                    { 164, "Dark Scroll for Gloves for HP 30%", 0, "gloves", "HP", 30 },
                    { 165, "Dark Scroll for Gloves for HP 100%", 0, "gloves", "HP", 70 },
                    { 166, "Scroll for Gloves for Magic Att. 10%", 0, "gloves", "MATT", 10 },
                    { 167, "Scroll for Gloves for Magic Att. 60%", 0, "gloves", "MATT", 60 },
                    { 168, "Scroll for Gloves for Magic Att. 100%", 0, "gloves", "MATT", 100 },
                    { 169, "Dark Scroll for Gloves for Magic Att. 30%", 0, "gloves", "MATT", 30 },
                    { 170, "Dark Scroll for Gloves for Magic Att. 70%", 0, "gloves", "MATT", 70 },
                    { 171, "Scroll for Shield for DEF 10%", 0, "shield", "DEF", 10 },
                    { 172, "Scroll for Shield for DEF 60%", 0, "shield", "DEF", 60 },
                    { 173, "Scroll for Shield for DEF 100%", 0, "shield", "DEF", 100 },
                    { 174, "Dark Scroll for Shield for DEF 30%", 0, "shield", "DEF", 30 },
                    { 175, "Dark Scroll for Shield for DEF 70%", 0, "shield", "DEF", 70 },
                    { 176, "Scroll for Shield for LUK 10%", 0, "shield", "LUK", 10 },
                    { 177, "Scroll for Shield for LUK 60%", 0, "shield", "LUK", 60 },
                    { 178, "Scroll for Shield for LUK 100%", 0, "shield", "LUK", 100 },
                    { 179, "Dark Scroll for Shield for LUK 30%", 0, "shield", "LUK", 30 },
                    { 180, "Dark Scroll for Shield for LUK 70%", 0, "shield", "LUK", 70 },
                    { 181, "Scroll for Shield for HP 10%", 0, "shield", "HP", 10 },
                    { 182, "Scroll for Shield for HP 60%", 0, "shield", "HP", 60 },
                    { 183, "Scroll for Shield for HP 100%", 0, "shield", "HP", 100 },
                    { 184, "Dark Scroll for Shield for HP 30%", 0, "shield", "HP", 30 },
                    { 185, "Dark Scroll for Shield for HP 70%", 0, "shield", "HP", 70 },
                    { 186, "Scroll for Shield for Weapon Att. 10%", 0, "shield", "ATT", 10 },
                    { 187, "Scroll for Shield for Weapon Att. 60%", 0, "shield", "ATT", 60 },
                    { 188, "Scroll for Shield for Weapon Att. 100%", 0, "shield", "ATT", 100 },
                    { 189, "Dark Scroll for Shield for Weapon Att. 30%", 0, "shield", "ATT", 30 },
                    { 190, "Dark Scroll for Shield for Weapon Att. 70%", 0, "shield", "ATT", 70 },
                    { 191, "Scroll for Shield for Magic Att. 10%", 0, "shield", "MATT", 10 },
                    { 192, "Scroll for Shield for Magic Att. 60%", 0, "shield", "MATT", 60 },
                    { 193, "Scroll for Shield for Magic Att. 100%", 0, "shield", "MATT", 100 },
                    { 194, "Dark Scroll for Shield for Magic Att. 30%", 0, "shield", "MATT", 30 },
                    { 195, "Dark Scroll for Shield for Magic Att. 70%", 0, "shield", "MATT", 70 },
                    { 196, "Scroll for Shield for STR 10%", 0, "shield", "STR", 10 },
                    { 197, "Scroll for Shield for STR 60%", 0, "shield", "STR", 60 },
                    { 198, "Scroll for Shield for STR 100%", 0, "shield", "STR", 100 },
                    { 199, "Dark Scroll for Shield for STR 30%", 0, "shield", "STR", 30 },
                    { 200, "Dark Scroll for Shield for STR 70%", 0, "shield", "STR", 70 },
                    { 201, "Scroll for Cape for Magic Def. 10%", 0, "cape", "MDEF", 10 },
                    { 202, "Scroll for Cape for Magic Def. 60%", 0, "cape", "MDEF", 60 },
                    { 203, "Scroll for Cape for Magic Def. 100%", 0, "cape", "MDEF", 100 },
                    { 204, "Dark Scroll for Cape for Magic Def. 30%", 0, "cape", "MDEF", 30 },
                    { 205, "Dark Scroll for Cape for Magic Def. 70%", 0, "cape", "MDEF", 70 },
                    { 206, "Scroll for Cape for Weapon Def. 10%", 0, "cape", "DEF", 10 },
                    { 207, "Scroll for Cape for Weapon Def. 60%", 0, "cape", "DEF", 60 },
                    { 208, "Scroll for Cape for Weapon Def. 100%", 0, "cape", "DEF", 100 },
                    { 209, "Dark Scroll for Cape for Weapon Def. 30%", 0, "cape", "DEF", 30 },
                    { 210, "Dark Scroll for Cape for Weapon Def. 70%", 0, "cape", "DEF", 70 },
                    { 211, "Scroll for Cape for HP 10%", 0, "cape", "HP", 10 },
                    { 212, "Scroll for Cape for HP 60%", 0, "cape", "HP", 60 },
                    { 213, "Scroll for Cape for HP 100%", 0, "cape", "HP", 100 },
                    { 214, "Dark Scroll for Cape for HP 30%", 0, "cape", "HP", 30 },
                    { 215, "Dark Scroll for Cape for HP 70%", 0, "cape", "HP", 70 },
                    { 216, "Scroll for Cape for MP 10%", 0, "cape", "MP", 10 },
                    { 217, "Scroll for Cape for MP 60%", 0, "cape", "MP", 60 },
                    { 218, "Scroll for Cape for MP 100%", 0, "cape", "MP", 100 },
                    { 219, "Dark Scroll for Cape for MP 30%", 0, "cape", "MP", 30 },
                    { 220, "Dark Scroll for Cape for MP 70%", 0, "cape", "MP", 70 },
                    { 221, "Scroll for Cape for STR 10%", 0, "cape", "STR", 10 },
                    { 222, "Scroll for Cape for STR 60%", 0, "cape", "STR", 60 },
                    { 223, "Scroll for Cape for STR 100%", 0, "cape", "STR", 100 },
                    { 224, "Dark Scroll for Cape for STR 30%", 0, "cape", "STR", 30 },
                    { 225, "Dark Scroll for Cape for STR 70%", 0, "cape", "STR", 70 },
                    { 226, "Scroll for Cape for INT 10%", 0, "cape", "INT", 10 },
                    { 227, "Scroll for Cape for INT 60%", 0, "cape", "INT", 60 },
                    { 228, "Scroll for Cape for INT 100%", 0, "cape", "INT", 100 },
                    { 229, "Dark Scroll for Cape for INT 30%", 0, "cape", "INT", 30 },
                    { 230, "Dark Scroll for Cape for INT 70%", 0, "cape", "INT", 70 },
                    { 231, "Scroll for Cape for DEX 10%", 0, "cape", "DEX", 10 },
                    { 232, "Scroll for Cape for DEX 60%", 0, "cape", "DEX", 60 },
                    { 233, "Scroll for Cape for DEX 100%", 0, "cape", "DEX", 100 },
                    { 234, "Dark Scroll for Cape for DEX 30%", 0, "cape", "DEX", 30 },
                    { 235, "Dark Scroll for Cape for DEX 70%", 0, "cape", "DEX", 70 },
                    { 236, "Scroll for Cape for LUK 10%", 0, "cape", "LUK", 10 },
                    { 237, "Scroll for Cape for LUK 60%", 0, "cape", "LUK", 60 },
                    { 238, "Scroll for Cape for LUK 100%", 0, "cape", "LUK", 100 },
                    { 239, "Dark Scroll for Cape for LUK 30%", 0, "cape", "LUK", 30 },
                    { 240, "Dark Scroll for Cape for LUK 70%", 0, "cape", "LUK", 70 },
                    { 241, "Scroll for One-handed Sword for ATT 10%", 0, "1HS", "ATT", 10 },
                    { 242, "Scroll for One-handed Sword for ATT 60%", 0, "1HS", "ATT", 60 },
                    { 243, "Scroll for One-handed Sword for ATT 100%", 0, "1HS", "ATT", 100 },
                    { 244, "Dark Scroll for One-handed Sword for ATT 30%", 0, "1HS", "ATT", 30 },
                    { 245, "Dark Scroll for One-handed Sword for ATT 70%", 0, "1HS", "ATT", 70 },
                    { 246, "Scroll for One-handed Sword for Magic Att. 10%", 0, "1HS", "MATT", 10 },
                    { 247, "Scroll for One-handed Sword for Magic Att. 60%", 0, "1HS", "MATT", 60 },
                    { 248, "Scroll for One-handed Sword for Magic Att. 100%", 0, "1HS", "MATT", 100 },
                    { 249, "Dark Scroll for One-handed Sword for Magic Att. 30%", 0, "1HS", "MATT", 30 },
                    { 250, "Dark Scroll for One-handed Sword for Magic Att. 70%", 0, "1HS", "MATT", 70 },
                    { 251, "Scroll for One-handed Sword for Accuracy 10%", 0, "1HS", "ACC", 10 },
                    { 252, "Scroll for One-handed Sword for Accuracy 60%", 0, "1HS", "ACC", 60 },
                    { 253, "Scroll for One-handed Sword for Accuracy 100%", 0, "1HS", "ACC", 100 },
                    { 254, "Dark Scroll for One-handed Sword for Accuracy 30%", 0, "1HS", "ACC", 30 },
                    { 255, "Dark Scroll for One-handed Sword for Accuracy 70%", 0, "1HS", "ACC", 70 },
                    { 256, "Scroll for One-handed Axe for Accuracy 10%", 0, "1HA", "ACC", 10 },
                    { 257, "Scroll for One-handed Axe for Accuracy 60%", 0, "1HA", "ACC", 60 },
                    { 258, "Scroll for One-handed Axe for Accuracy 100%", 0, "1HA", "ACC", 100 },
                    { 259, "Dark Scroll for One-handed Axe for Accuracy 30%", 0, "1HA", "ACC", 30 },
                    { 260, "Dark Scroll for One-handed Axe for Accuracy 70%", 0, "1HA", "ACC", 70 },
                    { 261, "Scroll for One-handed Axe for ATT 10%", 0, "1HA", "ATT", 10 },
                    { 262, "Scroll for One-handed Axe for ATT 60%", 0, "1HA", "ATT", 60 },
                    { 263, "Scroll for One-handed Axe for ATT 100%", 0, "1HA", "ATT", 100 },
                    { 264, "Dark Scroll for One-handed Axe for ATT 30%", 0, "1HA", "ATT", 30 },
                    { 265, "Dark Scroll for One-handed Axe for ATT 70%", 0, "1HA", "ATT", 70 },
                    { 266, "Scroll for One-handed BW for Accuracy 10%", 0, "1HBW", "ACC", 10 },
                    { 267, "Scroll for One-handed BW for Accuracy 60%", 0, "1HBW", "ACC", 60 },
                    { 268, "Scroll for One-handed BW for Accuracy 100%", 0, "1HBW", "ACC", 100 },
                    { 269, "Dark Scroll for One-handed BW for Accuracy 30%", 0, "1HBW", "ACC", 30 },
                    { 270, "Dark Scroll for One-handed BW for Accuracy 70%", 0, "1HBW", "ACC", 70 },
                    { 271, "Scroll for One-handed BW for ATT 10%", 0, "1HBW", "ATT", 10 },
                    { 272, "Scroll for One-handed BW for ATT 60%", 0, "1HBW", "ATT", 60 },
                    { 273, "Scroll for One-handed BW for ATT 100%", 0, "1HBW", "ATT", 100 },
                    { 274, "Dark Scroll for One-handed BW for ATT 30%", 0, "1HBW", "ATT", 30 },
                    { 275, "Dark Scroll for One-handed BW for ATT 70%", 0, "1HBW", "ATT", 70 },
                    { 276, "Scroll for Dagger for ATT 10%", 0, "dagger", "ATT", 10 },
                    { 277, "Scroll for Dagger for ATT 60%", 0, "dagger", "ATT", 60 },
                    { 278, "Scroll for Dagger for ATT 100%", 0, "dagger", "ATT", 100 },
                    { 279, "Dark Scroll for Dagger for ATT 30%", 0, "dagger", "ATT", 30 },
                    { 280, "Dark Scroll for Dagger for ATT 70%", 0, "dagger", "ATT", 70 },
                    { 281, "Scroll for Wand for Magic Att. 10%", 0, "wand", "MATT", 10 },
                    { 282, "Scroll for Wand for Magic Att. 60%", 0, "wand", "MATT", 60 },
                    { 283, "Scroll for Wand for Magic Att. 100%", 0, "wand", "MATT", 100 },
                    { 284, "Dark Scroll for Wand for Magic Att. 30%", 0, "wand", "MATT", 30 },
                    { 285, "Dark Scroll for Wand for Magic Att. 70%", 0, "wand", "MATT", 70 },
                    { 286, "Scroll for Staff for Magic Att. 10%", 0, "staff", "MATT", 10 },
                    { 287, "Scroll for Staff for Magic Att. 60%", 0, "staff", "MATT", 60 },
                    { 288, "Scroll for Staff for Magic Att. 100%", 0, "staff", "MATT", 100 },
                    { 289, "Dark Scroll for Staff for Magic Att. 30%", 0, "staff", "MATT", 30 },
                    { 290, "Dark Scroll for Staff for Magic Att. 70%", 0, "staff", "MATT", 70 },
                    { 291, "Scroll for Two-handed Sword for ATT 10%", 0, "2HS", "ATT", 10 },
                    { 292, "Scroll for Two-handed Sword for ATT 60%", 0, "2HS", "ATT", 60 },
                    { 293, "Scroll for Two-handed Sword for ATT 100%", 0, "2HS", "ATT", 100 },
                    { 294, "Dark Scroll for Two-handed Sword for ATT 30%", 0, "2HS", "ATT", 30 },
                    { 295, "Dark Scroll for Two-handed Sword for ATT 70%", 0, "2HS", "ATT", 70 },
                    { 296, "Scroll for Two-handed Sword for Accuracy 10%", 0, "2HS", "ACC", 10 },
                    { 297, "Scroll for Two-handed Sword for Accuracy 60%", 0, "2HS", "ACC", 60 },
                    { 298, "Scroll for Two-handed Sword for Accuracy 100%", 0, "2HS", "ACC", 100 },
                    { 299, "Dark Scroll for Two-handed Sword for Accuracy 30%", 0, "2HS", "ACC", 30 },
                    { 300, "Dark Scroll for Two-handed Sword for Accuracy 70%", 0, "2HS", "ACC", 70 },
                    { 301, "Scroll for Two-handed Axe for ATT 10%", 0, "2HA", "ATT", 10 },
                    { 302, "Scroll for Two-handed Axe for ATT 60%", 0, "2HA", "ATT", 60 },
                    { 303, "Scroll for Two-handed Axe for ATT 100%", 0, "2HA", "ATT", 100 },
                    { 304, "Dark Scroll for Two-handed Axe for ATT 30%", 0, "2HA", "ATT", 30 },
                    { 305, "Dark Scroll for Two-handed Axe for ATT 70%", 0, "2HA", "ATT", 70 },
                    { 306, "Scroll for Two-handed Axe for Accuracy 10%", 0, "2HA", "ACC", 10 },
                    { 307, "Scroll for Two-handed Axe for Accuracy 60%", 0, "2HA", "ACC", 60 },
                    { 308, "Scroll for Two-handed Axe for Accuracy 100%", 0, "2HA", "ACC", 100 },
                    { 309, "Dark Scroll for Two-handed Axe for Accuracy 30%", 0, "2HA", "ACC", 30 },
                    { 310, "Dark Scroll for Two-handed Axe for Accuracy 70%", 0, "2HA", "ACC", 70 },
                    { 311, "Scroll for Two-handed BW for ATT 10%", 0, "2HBW", "ATT", 10 },
                    { 312, "Scroll for Two-handed BW for ATT 60%", 0, "2HBW", "ATT", 60 },
                    { 313, "Scroll for Two-handed BW for ATT 100%", 0, "2HBW", "ATT", 100 },
                    { 314, "Dark Scroll for Two-handed BW for ATT 30%", 0, "2HBW", "ATT", 30 },
                    { 315, "Dark Scroll for Two-handed BW for ATT 70%", 0, "2HBW", "ATT", 70 },
                    { 316, "Scroll for Two-handed BW for Accuracy 10%", 0, "2HBW", "ACC", 10 },
                    { 317, "Scroll for Two-handed BW for Accuracy 60%", 0, "2HBW", "ACC", 60 },
                    { 318, "Scroll for Two-handed BW for Accuracy 100%", 0, "2HBW", "ACC", 100 },
                    { 319, "Dark Scroll for Two-handed BW for Accuracy 30%", 0, "2HBW", "ACC", 30 },
                    { 320, "Dark Scroll for Two-handed BW for Accuracy 70%", 0, "2HBW", "ACC", 70 },
                    { 321, "Scroll for Spear for ATT 10%", 0, "spear", "ATT", 10 },
                    { 322, "Scroll for Spear for ATT 60%", 0, "spear", "ATT", 60 },
                    { 323, "Scroll for Spear for ATT 100%", 0, "spear", "ATT", 100 },
                    { 324, "Dark Scroll for Spear for ATT 30%", 0, "spear", "ATT", 30 },
                    { 325, "Dark Scroll for Spear for ATT 70%", 0, "spear", "ATT", 70 },
                    { 326, "Scroll for Spear for Accuracy 10%", 0, "spear", "ACC", 10 },
                    { 327, "Scroll for Spear for Accuracy 60%", 0, "spear", "ACC", 60 },
                    { 328, "Scroll for Spear for Accuracy 100%", 0, "spear", "ACC", 100 },
                    { 329, "Dark Scroll for Spear for Accuracy 30%", 0, "spear", "ACC", 30 },
                    { 330, "Dark Scroll for Spear for Accuracy 70%", 0, "spear", "ACC", 70 },
                    { 331, "Scroll for Pole Arm for ATT 10%", 0, "polearm", "ATT", 10 },
                    { 332, "Scroll for Pole Arm for ATT 60%", 0, "polearm", "ATT", 60 },
                    { 333, "Scroll for Pole Arm for ATT 100%", 0, "polearm", "ATT", 100 },
                    { 334, "Dark Scroll for Pole Arm for ATT 30%", 0, "polearm", "ATT", 30 },
                    { 335, "Dark Scroll for Pole Arm for ATT 70%", 0, "polearm", "ATT", 70 },
                    { 336, "Scroll for Pole Arm for Accuracy 10%", 0, "polearm", "ACC", 10 },
                    { 337, "Scroll for Pole Arm for Accuracy 60%", 0, "polearm", "ACC", 60 },
                    { 338, "Scroll for Pole Arm for Accuracy 100%", 0, "polearm", "ACC", 100 },
                    { 339, "Dark Scroll for Pole Arm for Accuracy 30%", 0, "polearm", "ACC", 30 },
                    { 340, "Dark Scroll for Pole Arm for Accuracy 70%", 0, "polearm", "ACC", 70 },
                    { 341, "Scroll for Bow for ATT 10%", 0, "bow", "ATT", 10 },
                    { 342, "Scroll for Bow for ATT 60%", 0, "bow", "ATT", 60 },
                    { 343, "Scroll for Bow for ATT 100%", 0, "bow", "ATT", 100 },
                    { 344, "Dark Scroll for Bow for ATT 30%", 0, "bow", "ATT", 30 },
                    { 345, "Dark Scroll for Bow for ATT 70%", 0, "bow", "ATT", 70 },
                    { 346, "Scroll for Crossbow for ATT 10%", 0, "crossbow", "ATT", 10 },
                    { 347, "Scroll for Crossbow for ATT 60%", 0, "crossbow", "ATT", 60 },
                    { 348, "Scroll for Crossbow for ATT 100%", 0, "crossbow", "ATT", 100 },
                    { 349, "Dark Scroll for Crossbow for ATT 30%", 0, "crossbow", "ATT", 30 },
                    { 350, "Dark Scroll for Crossbow for ATT 70%", 0, "crossbow", "ATT", 70 },
                    { 351, "Scroll for Claw for ATT 10%", 0, "claw", "ATT", 10 },
                    { 352, "Scroll for Claw for ATT 60%", 0, "claw", "ATT", 60 },
                    { 353, "Scroll for Claw for ATT 100%", 0, "claw", "ATT", 100 },
                    { 354, "Dark Scroll for Claw for ATT 30%", 0, "claw", "ATT", 30 },
                    { 355, "Dark Scroll for Claw for ATT 70%", 0, "claw", "ATT", 70 },
                    { 356, "Scroll for Knuckler for Attack 10%", 0, "knuckle", "ATT", 10 },
                    { 357, "Scroll for Knuckler for Attack 60%", 0, "knuckle", "ATT", 60 },
                    { 358, "Scroll for Knuckler for Attack 100%", 0, "knuckle", "ATT", 100 },
                    { 359, "Dark Scroll for Knuckler for Attack 30%", 0, "knuckle", "ATT", 30 },
                    { 360, "Dark Scroll for Knuckler for Attack 70%", 0, "knuckle", "ATT", 70 },
                    { 361, "Scroll for Knuckle for Accuracy 10%", 0, "knuckle", "ACC", 10 },
                    { 362, "Scroll for Knuckle for Accuracy 60%", 0, "knuckle", "ACC", 60 },
                    { 363, "Scroll for Knuckle for Accuracy 100%", 0, "knuckle", "ACC", 100 },
                    { 364, "Dark Scroll for Knuckle for Accuracy 30%", 0, "knuckle", "ACC", 30 },
                    { 365, "Dark Scroll for Knuckle for Accuracy 70%", 0, "knuckle", "ACC", 70 },
                    { 366, "Scroll for Gun for ATT 10%", 0, "gun", "ATT", 10 },
                    { 367, "Scroll for Gun for Attack 60%", 0, "gun", "ATT", 60 },
                    { 368, "Scroll for Gun for Attack 100%", 0, "gun", "ATT", 100 },
                    { 369, "Dark Scroll for Gun for Attack 30%", 0, "gun", "ATT", 30 },
                    { 370, "Dark Scroll for Gun for Attack 70%", 0, "gun", "ATT", 70 },
                    { 371, "Scroll for Pet Equip. for HP 10%", 0, "pet", "HP", 10 },
                    { 372, "Scroll for Pet Equip. for HP 60%", 0, "pet", "HP", 60 },
                    { 373, "Scroll for Pet Equip. for HP 100%", 0, "pet", "HP", 100 },
                    { 374, "Dark Scroll for Pet Equip. for HP 30%", 0, "pet", "HP", 30 },
                    { 375, "Dark Scroll for Pet Equip. for HP 70%", 0, "pet", "HP", 70 },
                    { 376, "Scroll for Eye Accessory for INT 10%", 0, "eye", "INT", 10 },
                    { 377, "Scroll for Eye Accessory for INT 60%", 0, "eye", "INT", 60 },
                    { 378, "Scroll for Eye Accessory for INT 100%", 0, "eye", "INT", 100 },
                    { 379, "Dark Scroll for Eye Accessory for INT 30%", 0, "eye", "INT", 30 },
                    { 380, "Dark Scroll for Eye Accessory for INT 70%", 0, "eye", "INT", 70 },
                    { 381, "Scroll for Spikes on Shoes 10%", 0, "shoes", "SPIKES", 10 },
                    { 382, "Scroll for Cape for Cold Protection 10%", 0, "cape", "COLD", 10 },
                    { 383, "Scroll for Pet Equip. for Speed 10%", 0, "pet", "SPEED", 10 },
                    { 384, "Scroll for Pet Equip. for Speed 60%", 0, "pet", "SPEED", 60 },
                    { 385, "Scroll for Pet Equip. for Speed 100%", 0, "pet", "SPEED", 100 },
                    { 386, "Scroll for Pet Equip. for Jump 10%", 0, "pet", "JUMP", 10 },
                    { 387, "Scroll for Pet Equip. for Jump 60%", 0, "pet", "JUMP", 60 },
                    { 388, "Scroll for Pet Equip. for Jump 100%", 0, "pet", "JUMP", 100 },
                    { 389, "Clean Slate Scroll 1%", 0, "all", "CLEAN", 1 },
                    { 390, "Clean Slate Scroll 3%", 0, "all", "CLEAN", 3 },
                    { 391, "Clean Slate Scroll 5%", 0, "all", "CLEAN", 5 },
                    { 392, "Clean Slate Scroll 20%", 0, "all", "CLEAN", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Scrolls",
                keyColumn: "Id",
                keyValue: 392);
        }
    }
}
