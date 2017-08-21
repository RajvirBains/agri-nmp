﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using SERVERAPI.ViewModels;
using SERVERAPI.Models;
using Newtonsoft.Json;
using SERVERAPI.Models.Impl;
using SERVERAPI.ViewComponents;

namespace SERVERAPI.Controllers
{
    public class NutrientsController : Controller
    {
        private IHostingEnvironment _env;
        private UserData _ud;

        public NutrientsController(IHostingEnvironment env, UserData ud)
        {
            _env = env;
            _ud = ud;
        }
        // GET: /<controller>/
        public IActionResult Calculate(string id)
        {
            CalculateViewModel cvm = new CalculateViewModel();
            cvm.fields = new List<Field>();

            Models.Impl.StaticData sd = new Models.Impl.StaticData();

            // not id entered so default to the first one for the farm
            if(id == null)
            {
                List<Field> fldLst = _ud.GetFields();

                if(fldLst.Count() == 0)
                {
                    cvm.fldsFnd = false;
                }
                else
                {
                    cvm.fldsFnd = true;
                    foreach(var f in fldLst)
                    {
                        cvm.fields.Add(f);
                    }
                    cvm.currFld = cvm.fields[0].fieldName;
                }
            }
            else
            {
                cvm.currFld = id;
                List<Field> fldLst = _ud.GetFields();
                cvm.fldsFnd = true;
                foreach (var f in fldLst)
                {
                    cvm.fields.Add(f);
                }
            }

            return View(cvm);
        }
        [HttpPost]
        public IActionResult Calculate(CalculateViewModel cvm)
        {

            return View(cvm);
        }

        public IActionResult ManureDetails(string fldName, int? id)
        {
            ManureDetailsViewModel mvm = new ManureDetailsViewModel();

            mvm.fieldName = fldName;
            mvm.title = id == null ? "Add" : "Edit";
            mvm.btnText = id == null ? "Calculate" : "Return";
            mvm.id = id;
            mvm.avail = "40";
            mvm.nh4 = "40";
            mvm.stdN = true;
            mvm.stdAvail = true;

            //var farmData = HttpContext.Session.GetObjectFromJson<FarmData>("FarmData");
            ManureDetailsSetup(ref mvm);

            if(id != null)
            {
                NutrientManure nm = _ud.GetFieldNutrientsManure(fldName, id.Value);

                mvm.avail = nm.nAvail.ToString();
                mvm.selRateOption = nm.unitId;
                mvm.selManOption = nm.manureId;
                mvm.selApplOption = nm.applicationId;
                mvm.rate = nm.rate.ToString();
                mvm.nh4 = nm.nh4Retention.ToString();
                mvm.yrN = nm.yrN.ToString();
                mvm.yrP2o5 = nm.yrP2o5.ToString();
                mvm.yrK2o = nm.yrK2o.ToString();
                mvm.ltN = nm.ltN.ToString();
                mvm.ltP2o5 = nm.ltP2o5.ToString();
                mvm.ltK2o = nm.ltK2o.ToString();
                Models.Impl.StaticData sd = new Models.Impl.StaticData();
                Models.StaticData.Manure man = sd.GetManure(HttpContext, nm.manureId);
                mvm.currUnit = man.solid_liquid;
                mvm.rateOptions = sd.GetUnitsDll(HttpContext, mvm.currUnit).ToList();

                mvm.stdN = Convert.ToDecimal(mvm.nh4) != 40 ? false : true;
                mvm.stdAvail = Convert.ToDecimal(mvm.avail) != 40 ? false : true;

            }
            else

            {
                mvm.yrN = "0.0";
                mvm.yrP2o5 = "0.0";
                mvm.yrK2o = "0.0";
                mvm.ltN = "0.0";
                mvm.ltP2o5 = "0.0";
                mvm.ltK2o = "0.0";
            }

            return PartialView(mvm);
        }
        [HttpPost]
        public IActionResult ManureDetails(ManureDetailsViewModel mvm)
        {
            ManureDetailsSetup(ref mvm);

            //var farmData = HttpContext.Session.GetObjectFromJson<FarmData>("FarmData");

            if(mvm.buttonPressed == "ResetN")
            {
                ModelState.Clear();
                mvm.buttonPressed = "";
                mvm.btnText = "Calculate";
                mvm.nh4 = "40";
                mvm.stdN = true;
                return View(mvm);
            }

            if (mvm.buttonPressed == "ResetA")
            {
                ModelState.Clear();
                mvm.buttonPressed = "";
                mvm.btnText = "Calculate";
                mvm.avail = "40";
                mvm.stdAvail = true;
                return View(mvm);
            }

            if (mvm.buttonPressed == "TypeChange")
            {
                ModelState.Clear();
                mvm.buttonPressed = "";
                mvm.btnText = "Calculate";

                if (mvm.selManOption != "")
                {
                    Models.Impl.StaticData sd = new Models.Impl.StaticData();
                    Models.StaticData.Manure man = sd.GetManure(HttpContext, mvm.selManOption);
                    if(mvm.currUnit != man.solid_liquid)
                    {
                        mvm.currUnit = man.solid_liquid;
                        mvm.rateOptions = sd.GetUnitsDll(HttpContext, mvm.currUnit).ToList();
                    }
                }
                return View(mvm);
            }

            if (ModelState.IsValid)
            {
                if (mvm.btnText == "Calculate")
                {
                    ModelState.Clear();
                    mvm.yrN = "1.1";
                    mvm.yrP2o5 = "2.2";
                    mvm.yrK2o = "3.3";
                    mvm.ltN = "4.4";
                    mvm.ltP2o5 = "5.5";
                    mvm.ltK2o = "6.6";

                    mvm.btnText = mvm.id == null ? "Add to Field" : "Update Field";

                    if(Convert.ToDecimal(mvm.nh4) != 40)
                    {
                        mvm.stdN = false;
                    }
                    if (Convert.ToDecimal(mvm.avail) != 40)
                    {
                        mvm.stdAvail = false;
                    }
                }
                else
                {
                    if(mvm.id == null)
                    {

                        NutrientManure nm = new NutrientManure()
                        {
                            manureId = mvm.selManOption,
                            applicationId = mvm.selApplOption,
                            unitId = mvm.selRateOption,
                            rate = Convert.ToDecimal(mvm.rate),
                            nh4Retention = Convert.ToDecimal(mvm.nh4),
                            nAvail = Convert.ToDecimal(mvm.avail),
                            yrN = Convert.ToDecimal(mvm.yrN),
                            yrP2o5 = Convert.ToDecimal(mvm.yrP2o5),
                            yrK2o = Convert.ToDecimal(mvm.yrK2o),
                            ltN = Convert.ToDecimal(mvm.ltN),
                            ltP2o5 = Convert.ToDecimal(mvm.ltP2o5),
                            ltK2o = Convert.ToDecimal(mvm.ltK2o)
                        };

                        _ud.AddFieldNutrientsManure(mvm.fieldName, nm);
                    }
                    else
                    {
                        NutrientManure nm = _ud.GetFieldNutrientsManure(mvm.fieldName, mvm.id.Value);
                        nm.manureId = mvm.selManOption;
                        nm.applicationId = mvm.selApplOption;
                        nm.unitId = mvm.selRateOption;
                        nm.rate = Convert.ToDecimal(mvm.rate);
                        nm.nh4Retention = Convert.ToDecimal(mvm.nh4);
                        nm.nAvail = Convert.ToDecimal(mvm.avail);
                        nm.yrN = Convert.ToDecimal(mvm.yrN);
                        nm.yrP2o5 = Convert.ToDecimal(mvm.yrP2o5);
                        nm.yrK2o = Convert.ToDecimal(mvm.yrK2o);
                        nm.ltN = Convert.ToDecimal(mvm.ltN);
                        nm.ltP2o5 = Convert.ToDecimal(mvm.ltP2o5);
                        nm.ltK2o = Convert.ToDecimal(mvm.ltK2o);

                        _ud.UpdateFieldNutrientsManure(mvm.fieldName, nm);
                    }
                    string target = "#manure";
                    string url = Url.Action("RefreshManureList", "Nutrients", new {fieldName = mvm.fieldName });
                    return Json(new { success = true, url = url, target = target });
                }
            }

            return PartialView(mvm);
        }
        private void ManureDetailsSetup(ref ManureDetailsViewModel mvm)
        {
            Models.Impl.StaticData sd = new Models.Impl.StaticData();

            mvm.manOptions = new List<Models.StaticData.SelectListItem>();
            mvm.manOptions = sd.GetManuresDll(HttpContext).ToList();

            mvm.applOptions = new List<Models.StaticData.SelectListItem>();
            mvm.applOptions = sd.GetApplicationsDll(HttpContext).ToList();

            mvm.rateOptions = new List<Models.StaticData.SelectListItem>();
            mvm.rateOptions = sd.GetUnitsDll(HttpContext, mvm.currUnit).ToList();

            return;
        }
        public IActionResult RefreshManureList(string fieldName)
        {
            return ViewComponent("CalcManure", new { fldName = fieldName });
        }
        public IActionResult RefreshFieldList(string fieldName)
        {
            return RedirectToAction("Calculate", "Nutrients");
            //return ViewComponent("FieldList");
        }
        [HttpGet]
        public ActionResult ManureDelete(string fldName, int id)
        {
            Models.Impl.StaticData sd = new Models.Impl.StaticData();
            ManureDeleteViewModel dvm = new ManureDeleteViewModel();
            dvm.id = id;
            dvm.fldName = fldName;

            NutrientManure nm = _ud.GetFieldNutrientsManure(fldName, id);
            dvm.matType = sd.GetManure(HttpContext, nm.manureId).name;

            dvm.act = "Delete";

            return PartialView("ManureDelete", dvm);
        }
        [HttpPost]
        public ActionResult ManureDelete(ManureDeleteViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                _ud.DeleteFieldNutrientsManure(dvm.fldName, dvm.id);

                string target = "#manure";
                string url = Url.Action("RefreshManureList", "Nutrients", new { fieldName = dvm.fldName });
                return Json(new { success = true, url = url, target = target });
            }
            return PartialView("ManureDelete", dvm);
        }
    }
}