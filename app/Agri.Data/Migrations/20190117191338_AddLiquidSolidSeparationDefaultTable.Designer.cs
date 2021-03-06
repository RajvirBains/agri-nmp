﻿// <auto-generated />
using System;
using Agri.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agri.Data.Migrations
{
    [DbContext(typeof(AgriConfigurationContext))]
    [Migration("20190117191338_AddLiquidSolidSeparationDefaultTable")]
    partial class AddLiquidSolidSeparationDefaultTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Agri.Models.Configuration.AmmoniaRetention", b =>
                {
                    b.Property<int>("SeasonApplicationId");

                    b.Property<int>("DryMatter");

                    b.Property<decimal?>("Value");

                    b.HasKey("SeasonApplicationId", "DryMatter");

                    b.HasAlternateKey("DryMatter", "SeasonApplicationId");

                    b.ToTable("AmmoniaRetentions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UseSortOrder");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Agri.Models.Configuration.AnimalSubType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnimalId");

                    b.Property<decimal?>("LiquidPerGalPerAnimalPerDay");

                    b.Property<decimal>("MilkProduction");

                    b.Property<string>("Name");

                    b.Property<decimal>("SolidLiquidSeparationPercentage");

                    b.Property<decimal?>("SolidPerGalPerAnimalPerDay");

                    b.Property<decimal?>("SolidPerPoundPerAnimalPerDay");

                    b.Property<int>("SortOrder");

                    b.Property<decimal>("WashWater");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalSubType");
                });

            modelBuilder.Entity("Agri.Models.Configuration.BCSampleDateForNitrateCredit", b =>
                {
                    b.Property<string>("CoastalFromDateMonth")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoastalToDateMonth");

                    b.Property<string>("InteriorFromDateMonth");

                    b.Property<string>("InteriorToDateMonth");

                    b.HasKey("CoastalFromDateMonth");

                    b.ToTable("BCSampleDateForNitrateCredit");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Browser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MinVersion");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Browsers");
                });

            modelBuilder.Entity("Agri.Models.Configuration.ConversionFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DefaultApplicationOfManureInPrevYears");

                    b.Property<int>("DefaultSoilTestKelownaPhosphorous");

                    b.Property<int>("DefaultSoilTestKelownaPotassium");

                    b.Property<decimal>("KilogramPerHectareToPoundPerAcreConversion");

                    b.Property<decimal>("NitrogenProteinConversion");

                    b.Property<decimal>("PhosphorousAvailabilityFirstYear");

                    b.Property<decimal>("PhosphorousAvailabilityLongTerm");

                    b.Property<decimal>("PhosphorousPtoP2O5Conversion");

                    b.Property<decimal>("PotassiumAvailabilityFirstYear");

                    b.Property<decimal>("PotassiumAvailabilityLongTerm");

                    b.Property<decimal>("PotassiumKtoK2OConversion");

                    b.Property<decimal>("PoundPer1000FtSquaredToPoundPerAcreConversion");

                    b.Property<decimal>("PoundPerTonConversion");

                    b.Property<decimal>("SoilTestPPMToPoundPerAcre");

                    b.Property<decimal>("UnitConversion");

                    b.HasKey("Id");

                    b.ToTable("ConversionFactors");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Crop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CropName");

                    b.Property<decimal?>("CropRemovalFactorK2O");

                    b.Property<decimal?>("CropRemovalFactorNitrogen");

                    b.Property<decimal?>("CropRemovalFactorP2O5");

                    b.Property<int>("CropTypeId");

                    b.Property<decimal?>("HarvestBushelsPerTon");

                    b.Property<int>("ManureApplicationHistory");

                    b.Property<decimal>("NitrogenRecommendationId");

                    b.Property<decimal?>("NitrogenRecommendationPoundPerAcre");

                    b.Property<decimal?>("NitrogenRecommendationUpperLimitPoundPerAcre");

                    b.Property<int>("PreviousCropCode");

                    b.Property<int>("SortNumber");

                    b.Property<int>("YieldCd");

                    b.HasKey("Id");

                    b.HasIndex("CropTypeId");

                    b.HasIndex("ManureApplicationHistory");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropSoilTestPhosphorousRegion", b =>
                {
                    b.Property<int>("CropId");

                    b.Property<int>("SoilTestPhosphorousRegionCode");

                    b.Property<int?>("PhosphorousCropGroupRegionCode");

                    b.HasKey("CropId", "SoilTestPhosphorousRegionCode");

                    b.ToTable("CropSoilTestPhosphorousRegions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropSoilTestPotassiumRegion", b =>
                {
                    b.Property<int>("CropId");

                    b.Property<int>("SoilTestPotassiumRegionCode");

                    b.Property<int?>("PotassiumCropGroupRegionCode");

                    b.HasKey("CropId", "SoilTestPotassiumRegionCode");

                    b.ToTable("CropSoilTestPotassiumRegions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CoverCrop");

                    b.Property<bool>("CrudeProteinRequired");

                    b.Property<bool>("CustomCrop");

                    b.Property<bool>("ModifyNitrogen");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CropTypes");
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropYield", b =>
                {
                    b.Property<int>("CropId");

                    b.Property<int>("LocationId");

                    b.Property<decimal?>("Amount");

                    b.HasKey("CropId", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("CropYields");
                });

            modelBuilder.Entity("Agri.Models.Configuration.DefaultSoilTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConvertedKelownaK");

                    b.Property<int>("ConvertedKelownaP");

                    b.Property<string>("DefaultSoilTestMethodId");

                    b.Property<decimal>("Nitrogen");

                    b.Property<decimal>("Phosphorous");

                    b.Property<decimal>("Potassium");

                    b.Property<decimal>("pH");

                    b.HasKey("Id");

                    b.ToTable("DefaultSoilTests");
                });

            modelBuilder.Entity("Agri.Models.Configuration.DensityUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConvFactor");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DensityUnits");
                });

            modelBuilder.Entity("Agri.Models.Configuration.DryMatter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DryMatters");
                });

            modelBuilder.Entity("Agri.Models.Configuration.ExternalLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("ExternalLinks");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Fertilizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DryLiquid");

                    b.Property<string>("Name");

                    b.Property<decimal>("Nitrogen");

                    b.Property<decimal>("Phosphorous");

                    b.Property<decimal>("Potassium");

                    b.Property<int>("SortNum");

                    b.HasKey("Id");

                    b.ToTable("Fertilizers");
                });

            modelBuilder.Entity("Agri.Models.Configuration.FertilizerMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FertilizerMethods");
                });

            modelBuilder.Entity("Agri.Models.Configuration.FertilizerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Custom");

                    b.Property<string>("DryLiquid");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FertilizerTypes");
                });

            modelBuilder.Entity("Agri.Models.Configuration.FertilizerUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConversionToImperialGallonsPerAcre");

                    b.Property<string>("DryLiquid");

                    b.Property<decimal>("FarmRequiredNutrientsStdUnitsAreaConversion");

                    b.Property<decimal>("FarmRequiredNutrientsStdUnitsConversion");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FertilizerUnits");
                });

            modelBuilder.Entity("Agri.Models.Configuration.HarvestUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HarvestUnits");
                });

            modelBuilder.Entity("Agri.Models.Configuration.LiquidFertilizerDensity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DensityUnitId");

                    b.Property<int>("FertilizerId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DensityUnitId");

                    b.HasIndex("FertilizerId");

                    b.ToTable("LiquidFertilizerDensities");
                });

            modelBuilder.Entity("Agri.Models.Configuration.LiquidMaterialApplicationUSGallonsPerAcreRateConversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationRateUnit");

                    b.Property<string>("ApplicationRateUnitName");

                    b.Property<decimal>("USGallonsPerAcreConversion");

                    b.HasKey("Id");

                    b.ToTable("LiquidMaterialApplicationUsGallonsPerAcreRateConversions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.LiquidMaterialsConversionFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InputUnit");

                    b.Property<string>("InputUnitName");

                    b.Property<decimal>("USGallonsOutput");

                    b.HasKey("Id");

                    b.ToTable("LiquidMaterialsConversionFactors");
                });

            modelBuilder.Entity("Agri.Models.Configuration.LiquidSolidSeparationDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PercentOfLiquidSeparation");

                    b.HasKey("Id");

                    b.ToTable("LiquidSolidSeparationDefaults");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Agri.Models.Configuration.MainMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MainMenus");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Manure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ammonia");

                    b.Property<decimal>("CubicYardConversion");

                    b.Property<int>("DMId");

                    b.Property<string>("ManureClass");

                    b.Property<string>("Moisture");

                    b.Property<int>("NMineralizationId");

                    b.Property<int?>("NMineralizationId1");

                    b.Property<int?>("NMineralizationLocationId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Nitrate");

                    b.Property<decimal>("Nitrogen");

                    b.Property<decimal>("Phosphorous");

                    b.Property<decimal>("Potassium");

                    b.Property<string>("SolidLiquid");

                    b.Property<int>("SortNum");

                    b.HasKey("Id");

                    b.HasIndex("DMId");

                    b.HasIndex("NMineralizationId1", "NMineralizationLocationId");

                    b.ToTable("Manures");
                });

            modelBuilder.Entity("Agri.Models.Configuration.ManureImportedDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("DefaultSolidMoisture");

                    b.HasKey("Id");

                    b.ToTable("ManureImportedDefaults");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Balance1High");

                    b.Property<int>("Balance1Low");

                    b.Property<int>("BalanceHigh");

                    b.Property<int>("BalanceLow");

                    b.Property<string>("BalanceType");

                    b.Property<string>("DisplayMessage");

                    b.Property<string>("Icon");

                    b.Property<decimal>("SoilTestHigh");

                    b.Property<decimal>("SoilTestLow");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Agri.Models.Configuration.NitrateCreditSampleDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FromDateMonth");

                    b.Property<string>("Location");

                    b.Property<string>("ToDateMonth");

                    b.HasKey("Id");

                    b.ToTable("NitrateCreditSampleDates");
                });

            modelBuilder.Entity("Agri.Models.Configuration.NitrogenMineralization", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("LocationId");

                    b.Property<decimal>("FirstYearValue");

                    b.Property<decimal>("LongTermValue");

                    b.Property<string>("Name");

                    b.HasKey("Id", "LocationId");

                    b.ToTable("NitrogenMineralizations");
                });

            modelBuilder.Entity("Agri.Models.Configuration.NitrogenRecommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RecommendationDesc");

                    b.HasKey("Id");

                    b.ToTable("NitrogenRecommendations");
                });

            modelBuilder.Entity("Agri.Models.Configuration.NutrientIcon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Definition");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("NutrientIcons");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PhosphorusSoilTestRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rating");

                    b.Property<int>("UpperLimit");

                    b.HasKey("Id");

                    b.ToTable("PhosphorusSoilTestRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PotassiumSoilTestRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rating");

                    b.Property<int>("UpperLimit");

                    b.HasKey("Id");

                    b.ToTable("PotassiumSoilTestRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PreviousCropType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CropId");

                    b.Property<int?>("CropTypeId");

                    b.Property<string>("Name");

                    b.Property<int>("NitrogenCreditImperial");

                    b.Property<int>("NitrogenCreditMetric");

                    b.Property<int>("PreviousCropCode");

                    b.HasKey("Id");

                    b.HasIndex("CropId");

                    b.HasIndex("CropTypeId");

                    b.ToTable("PreviousCropType");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PreviousManureApplicationYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FieldManureApplicationHistory");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PrevManureApplicationYears");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PreviousYearManureApplicationNitrogenDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int[]>("DefaultNitrogenCredit");

                    b.Property<int>("FieldManureApplicationHistory");

                    b.Property<string>("PreviousYearManureAplicationFrequency");

                    b.HasKey("Id");

                    b.ToTable("PrevYearManureApplicationNitrogenDefaults");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<int>("SoilTestPhosphorousRegionCd");

                    b.Property<int>("SoilTestPotassiumRegionCd");

                    b.Property<int>("SortNumber");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.RptCompletedFertilizerRequiredStdUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LiquidUnitId");

                    b.Property<int>("SolidUnitId");

                    b.HasKey("Id");

                    b.ToTable("RptCompletedFertilizerRequiredStdUnits");
                });

            modelBuilder.Entity("Agri.Models.Configuration.RptCompletedManureRequiredStdUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LiquidUnitId");

                    b.Property<int>("SolidUnitId");

                    b.HasKey("Id");

                    b.ToTable("RptCompletedManureRequiredStdUnits");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SeasonApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationMethod");

                    b.Property<string>("Compost");

                    b.Property<decimal>("DryMatter1To5Percent");

                    b.Property<decimal>("DryMatter5To10Percent");

                    b.Property<decimal>("DryMatterGreaterThan10Percent");

                    b.Property<decimal>("DryMatterLessThan1Percent");

                    b.Property<string>("ManureType");

                    b.Property<string>("Name");

                    b.Property<string>("PoultrySolid");

                    b.Property<string>("Season");

                    b.Property<int>("SortNum");

                    b.HasKey("Id");

                    b.ToTable("SeasonApplications");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SelectCodeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cd");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("SelectCodeItems");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SelectListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("SelectListItems");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConvertToKelownaK");

                    b.Property<decimal>("ConvertToKelownaPHGreaterThanEqual72");

                    b.Property<decimal>("ConvertToKelownaPHLessThan72");

                    b.Property<string>("Name");

                    b.Property<int>("SortNum");

                    b.HasKey("Id");

                    b.ToTable("SoilTestMethods");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPhosphorousKelownaRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Range");

                    b.Property<int>("RangeHigh");

                    b.Property<int>("RangeLow");

                    b.HasKey("Id");

                    b.ToTable("SoilTestPhosphorousKelownaRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPhosphorousRecommendation", b =>
                {
                    b.Property<int>("SoilTestPhosphorousKelownaRangeId");

                    b.Property<int>("SoilTestPhosphorousRegionCode");

                    b.Property<int>("PhosphorousCropGroupRegionCode");

                    b.Property<int>("P2O5RecommendationKilogramPerHectare");

                    b.HasKey("SoilTestPhosphorousKelownaRangeId", "SoilTestPhosphorousRegionCode", "PhosphorousCropGroupRegionCode");

                    b.HasAlternateKey("PhosphorousCropGroupRegionCode", "SoilTestPhosphorousKelownaRangeId", "SoilTestPhosphorousRegionCode");

                    b.ToTable("SoilTestPhosphorousRecommendation");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPhosphorusRange", b =>
                {
                    b.Property<int>("UpperLimit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rating");

                    b.HasKey("UpperLimit");

                    b.ToTable("SoilTestPhosphorusRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPotassiumKelownaRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Range");

                    b.Property<int>("RangeHigh");

                    b.Property<int>("RangeLow");

                    b.HasKey("Id");

                    b.ToTable("SoilTestPotassiumKelownaRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPotassiumRange", b =>
                {
                    b.Property<int>("UpperLimit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Rating");

                    b.HasKey("UpperLimit");

                    b.ToTable("SoilTestPotassiumRanges");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPotassiumRecommendation", b =>
                {
                    b.Property<int>("SoilTestPotassiumKelownaRangeId");

                    b.Property<int>("SoilTestPotassiumRegionCode");

                    b.Property<int>("PotassiumCropGroupRegionCode");

                    b.Property<int>("K2ORecommendationKilogramPerHectare");

                    b.HasKey("SoilTestPotassiumKelownaRangeId", "SoilTestPotassiumRegionCode", "PotassiumCropGroupRegionCode");

                    b.HasAlternateKey("PotassiumCropGroupRegionCode", "SoilTestPotassiumKelownaRangeId", "SoilTestPotassiumRegionCode");

                    b.ToTable("SoilTestPotassiumRecommendation");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SolidMaterialApplicationTonPerAcreRateConversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationRateUnit");

                    b.Property<string>("ApplicationRateUnitName");

                    b.Property<string>("TonsPerAcreConversion");

                    b.HasKey("Id");

                    b.ToTable("SolidMaterialApplicationTonPerAcreRateConversions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SolidMaterialsConversionFactor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CubicMetersOutput");

                    b.Property<string>("CubicYardsOutput");

                    b.Property<int>("InputUnit");

                    b.Property<string>("InputUnitName");

                    b.Property<string>("MetricTonsOutput");

                    b.HasKey("Id");

                    b.ToTable("SolidMaterialsConversionFactors");
                });

            modelBuilder.Entity("Agri.Models.Configuration.SubMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<int>("MainMenuId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MainMenuId");

                    b.ToTable("SubMenu");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConversionlbTon");

                    b.Property<decimal>("CostApplications");

                    b.Property<string>("CostUnits");

                    b.Property<string>("DollarUnitArea");

                    b.Property<decimal>("FarmReqdNutrientsStdUnitsAreaConversion");

                    b.Property<decimal>("FarmReqdNutrientsStdUnitsConversion");

                    b.Property<string>("Name");

                    b.Property<string>("NutrientContentUnits");

                    b.Property<string>("NutrientRateUnits");

                    b.Property<string>("SolidLiquid");

                    b.Property<decimal>("ValueK2O");

                    b.Property<string>("ValueMaterialUnits");

                    b.Property<decimal>("ValueN");

                    b.Property<decimal>("ValueP2O5");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Agri.Models.Configuration.UserPrompt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("UserPrompts");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Version", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StaticDataVersion");

                    b.HasKey("Id");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("Agri.Models.Configuration.Yield", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("YieldDesc");

                    b.HasKey("Id");

                    b.ToTable("Yields");
                });

            modelBuilder.Entity("Agri.Models.Data.AppliedMigrationSeedData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AppliedDateTime");

                    b.Property<string>("JsonFilename");

                    b.Property<string>("ReasonReference");

                    b.HasKey("Id");

                    b.ToTable("AppliedMigrationSeedData");
                });

            modelBuilder.Entity("Agri.Models.Configuration.AnimalSubType", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Animal", "Animal")
                        .WithMany("AnimalSubTypes")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.Crop", b =>
                {
                    b.HasOne("Agri.Models.Configuration.CropType", "CropType")
                        .WithMany("Crops")
                        .HasForeignKey("CropTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Agri.Models.Configuration.PreviousYearManureApplicationNitrogenDefault", "PreviousYearManureApplicationNitrogenDefault")
                        .WithMany("Crops")
                        .HasForeignKey("ManureApplicationHistory")
                        .HasPrincipalKey("FieldManureApplicationHistory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropSoilTestPhosphorousRegion", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Crop")
                        .WithMany("CropSoilTestPhosphorousRegions")
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropSoilTestPotassiumRegion", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Crop")
                        .WithMany("CropSoilTestPotassiumRegions")
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.CropYield", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Crop", "Crop")
                        .WithMany("CropYields")
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Agri.Models.Configuration.Location", "Location")
                        .WithMany("CropYields")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.LiquidFertilizerDensity", b =>
                {
                    b.HasOne("Agri.Models.Configuration.DensityUnit", "DensityUnit")
                        .WithMany("LiquidFertilizerDensities")
                        .HasForeignKey("DensityUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Agri.Models.Configuration.Fertilizer", "Fertilizer")
                        .WithMany("LiquidFertilizerDensities")
                        .HasForeignKey("FertilizerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.Manure", b =>
                {
                    b.HasOne("Agri.Models.Configuration.DryMatter", "Dm")
                        .WithMany()
                        .HasForeignKey("DMId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Agri.Models.Configuration.NitrogenMineralization", "NMineralization")
                        .WithMany("Manures")
                        .HasForeignKey("NMineralizationId1", "NMineralizationLocationId");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PreviousCropType", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Crop")
                        .WithMany("PreviousCropTypes")
                        .HasForeignKey("CropId");

                    b.HasOne("Agri.Models.Configuration.CropType")
                        .WithMany("PrevCropTypes")
                        .HasForeignKey("CropTypeId");
                });

            modelBuilder.Entity("Agri.Models.Configuration.PreviousYearManureApplicationNitrogenDefault", b =>
                {
                    b.HasOne("Agri.Models.Configuration.PreviousManureApplicationYear", "PreviousManureApplicationYear")
                        .WithMany("PreviousYearManureApplicationNitrogenDefaults")
                        .HasForeignKey("FieldManureApplicationHistory")
                        .HasPrincipalKey("FieldManureApplicationHistory")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.Region", b =>
                {
                    b.HasOne("Agri.Models.Configuration.Location")
                        .WithMany("Regions")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPhosphorousRecommendation", b =>
                {
                    b.HasOne("Agri.Models.Configuration.SoilTestPhosphorousKelownaRange", "SoilTestPhosphorousKelownaRange")
                        .WithMany("SoilTestPhosphorousRecommendations")
                        .HasForeignKey("SoilTestPhosphorousKelownaRangeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.SoilTestPotassiumRecommendation", b =>
                {
                    b.HasOne("Agri.Models.Configuration.SoilTestPotassiumKelownaRange", "SoilTestPotassiumKelownaRange")
                        .WithMany("SoilTestPotassiumRecommendations")
                        .HasForeignKey("SoilTestPotassiumKelownaRangeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Agri.Models.Configuration.SubMenu", b =>
                {
                    b.HasOne("Agri.Models.Configuration.MainMenu", "MainMenu")
                        .WithMany("SubMenus")
                        .HasForeignKey("MainMenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
