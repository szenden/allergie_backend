/* Create database */
CREATE DATABASE AllergieDB;
GO

/* Create schema */
USE AllergieDB;
GO
CREATE SCHEMA allergie_dev;
GO

/* Change to the AllergieDB database */
USE AllergieDB;
GO

/* Create tables */
-- drop table allergie_dev.Products;
CREATE TABLE allergie_dev.Products (
    product_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    barcode nvarchar(max) NULL,
    product_name nvarchar(max) NULL,
    brands nvarchar(max) NULL,
    nutrition_grades nvarchar(max) NULL,
    product_image nvarchar(max) NULL,
    product_thumbnail nvarchar(max) NULL,
    key_words nvarchar(max) NULL,
    nutritient_levels nvarchar(max) NULL,
    quantity nvarchar(max) NULL,
    creator nvarchar(max) NULL,
    nutriments nvarchar(max) NULL,
    categories nvarchar(max) NULL,
    ingredients_text nvarchar(max) NULL,
    additives nvarchar(max) NULL,
    allergens nvarchar(max) null,
    original_id nvarchar(max) null,
    raw_json nvarchar(max) NULL,
    created_on datetime2 NULL,
    created_by nvarchar(max) NULL,
    modified_on datetime2 NULL,
    modified_by nvarchar(max) NULL
);
-- drop TABLE allergie_dev.Ingredients;
CREATE TABLE allergie_dev.Ingredients (
    ingredient_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    product_id int NULL,
    vegetarian nvarchar(max) NULL,
    text nvarchar(max) NULL,
    vegan nvarchar(max) NULL,
    original_ingredient_id nvarchar(max) NULL,
    rank int NULL,
    ing_percent nvarchar(max) null,
    has_sub_ingredients nvarchar(max) NULL,
    created_on datetime2 NULL,
    created_by nvarchar(max) NULL,
    modified_on datetime2 NULL,
    modified_by nvarchar(max) NULL
);
-- drop TABLE allergie_dev.Allergies;
CREATE TABLE allergie_dev.Allergies
 (
    allergy_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ingredient_id int null,
    url nvarchar(max) NULL,
    name nvarchar(max) NULL,
    original_id nvarchar(max) NULL,
    products int NULL,
    same_as nvarchar(max) NULL,
    ingredients_with_allergies nvarchar(max) NULL,
    ingredients_analysis_tags nvarchar(max) NULL,
    allergens_from_ingredients nvarchar(max) NULL,
    allergens nvarchar(max) NULL,
    allergens_tags nvarchar(max) NULL,
    created_on datetime2 NULL,
    created_by nvarchar(max) NULL,
    modified_on datetime2 NULL,
    modified_by nvarchar(max) NULL
);
GO

-- drop TABLE allergie_dev.Additives;
CREATE TABLE allergie_dev.Additives
 (
    addictive_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    url nvarchar(max) NULL,
    name nvarchar(max) NULL,
    original_id nvarchar(max) NULL,
    products int NULL,
    same_as nvarchar(max) NULL,
    created_on datetime2 NULL,
    created_by nvarchar(max) NULL,
    modified_on datetime2 NULL,
    modified_by nvarchar(max) NULL
);
GO