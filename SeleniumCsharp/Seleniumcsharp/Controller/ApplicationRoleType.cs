using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TREDS.Virginia.Gov.QA.Controller
{

    public enum ApplicationRoleType
    {
        [Description("DMV Backoffice Manager")]
        BackofficeManager,
        [Description("DMV Backoffice Clerk")]
        BackofficeClerk,
        [Description("Integration Services Users")]
        IntegrationServicesUsers,
        [Description("Motorcycle Safety Manager")]
        MotorcycleSafetyManager,
        [Description("Submit Crash Reports to Supervisor")]
        SubmitCrashReportsToSupervisor,
        [Description("Submit and Approve Crash Reports")]
        SubmitAndApproveCrashReports,
        [Description("DMV R-A Analyst")]
        RAAnalyst,
        [Description("DMV R-A Manager")]
        RAManager,
        [Description("Law Enforcement Clerk")]
        LawEnforcementClerk,
        [Description("Motorcycle Safety Analyst")]
        MotorcycleSafetyAnalyst,
        [Description("Motorcycle Training User")]
        MotorcycleTrainingUser,
        [Description("Motorcycle Training Report Analyst")]
        MotorcycleTrainingReportAnalyst,
        [Description("Motorcycle Community College Report Analyst")]
        MotorcycleCommunityCollegeReportAnalyst,
        [Description("Motorcycle Private Vendor Report Analyst")]
        MotorcyclePrivateVendorReportAnalyst,
        [Description("Motorcycle VCCS Report Analyst")]
        MotorcycleVCCSReportAnalyst,
        [Description("MCS Program Manager")]
        MCSProgramManager, //Motorcycle Safety Program Manager
        [Description("System Administrator")]
        SystemAdministrator,
        [Description("Department Administrator")]
        DepartmentAdministrator,
        [Description("DUI Data Entry Users")]
        DUIDataEntryUsers,
        [Description("DUI Program Manager")]
        DUIProgramManager,
        [Description("DUI Regional Manager")]
        DUIRegionalManager,
        [Description("DUI Reports")]
        DUIReports,
        [Description("CIOT Data Entry Users")]
        CIOTDataEntryUsers,
        [Description("CIOT Program Manager")]
        CIOTProgramManager,
        [Description("CIOT Reports")]
        CIOTReports,
        [Description("Agency Analyst")]
        AgencyAnalyst,
        [Description("VDOT RNS Users")]
        VDOTRNSUsers,
        //TODO: Delete the following two role types, as they were added temporarely for RMSIntegration.
        //Start
        [Description("RMS Crashes By Dept")]
        RMSCrashesByDept,
        [Description("RMS Full Crash Copy")]
        RMSFullCrashCopy,
        //End
        [Description("VSP Admin")]
        VSPAdmin,
        [Description("DMV Records Group")]
        DMVRecordsGroup,
        [Description("DMV Records Group Supervisor")]
        DMVRecordsGroupSupervisor,
        [Description("Reporting Analyst")]
        ReportingAnalyst,
        [Description("Search and Print Crash Reports")]
        SearchAndPrintCrashReports,
        [Description("FMCSA State Program Manager")]
        FMCSAStateProgramManager,
        [Description("VAHSO Program Manager")]
        VAHSOProgramManager,
        [Description("Systems Support Group")]
        SystemsSupportGroup
    }

    /// <summary>
    /// Added the new extension class method to get the EnumDescription.
    /// </summary>
    public static class ApplicationRoleTypeExtensions
    {
        public static string GetDescription(this ApplicationRoleType pEnum)
        {
            return EnumHelper.GetEnumDescription(typeof(ApplicationRoleType), pEnum.ToString());
        }
    }
}
