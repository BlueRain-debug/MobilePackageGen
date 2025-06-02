# Mobile Package Gen - Create Mobile Packages from various image types

## Copyright

Copyright (c) 2025, Gustave Monce - gus33000.me - @gus33000

This software is released under the MIT license, for more information please see LICENSE.md

## Description

This tool enables creating CBS and SPKG packages out of:

- FFU Files (GPT)
- VHDX Files (with OS Pools (x64 only)) (GPT)
- VHDX Files (without OS Pools) (GPT)
- VHD Files (GPT)
- Mass Storage (GPT)
- Raw IMG (GPT)

## Usage

### Command

```batch
MobilePackageGen.exe E:\DeviceImage\Flash.ffu E:\DeviceImage\FlashOutputCabs
```

### Command Output

```batch
Mobile Package Generator Tool
Version: 1.0.7.0

[23:41:27][Information] Getting Disks...

[23:41:27][Information] RM1085_1078.0053.10586.13169.12547.035242_retail_prod_signed.ffu 3085041664 FullFlashUpdate
[23:41:27][Information] - 0:  18253611008 FullFlashUpdateStore

[23:41:27][Information] Getting Update OS Disks...

[23:41:27][Information] UpdateOS.wim 36439143 WindowsImageFile
[23:41:27][Information] - 0 WindowsImageIndex


[23:41:27][Information] Found partitions with recognized file system:

[23:41:27][Information] LogFS fd2567d5-e82c-4389-9c76-3302e6b078fa bc0330eb-3410-4951-a617-03898dbe3372 16777216 KnownFS
[23:41:27][Information] TZAPPS 3e67f490-a1ec-48e6-98f6-7a63ae4e7561 14d11c40-2a3d-4f97-882d-103a1ec09333 16777216 KnownFS
[23:41:27][Information] PLAT d70bc079-1f6c-48e9-8fe0-51c2fa07546d 543c031a-4cb6-4897-bffe-4b485768a8ad 8388608 KnownFS
[23:41:27][Information] EFIESP 8183040a-8b44-4592-92f7-c6d9ee0560f7 ebd0a0a2-b9e5-4433-87c0-68b6b72699c7 33554432 KnownFS
[23:41:27][Information] MMOS 27a47557-8243-4c8e-9d30-846844c29c52 ebd0a0a2-b9e5-4433-87c0-68b6b72699c7 6291456 KnownFS
[23:41:27][Information] MainOS a76b8ce2-0187-4c13-8fca-8651c9b0620a ebd0a0a2-b9e5-4433-87c0-68b6b72699c7 3064987648 KnownFS
[23:41:27][Information] Data dbcb03c6-87db-449a-9b0e-ac32847f0f70 ebd0a0a2-b9e5-4433-87c0-68b6b72699c7 15005122560 KnownFS
[23:41:27][Information] MainOS-UpdateOS-0 00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-000000000000 36439143 KnownFS

[23:41:27][Information] Found partitions with unrecognized file system:

[23:41:27][Information] DPP 60b65587-3da5-43a0-96dc-219dae09a490 ebd0a0a2-b9e5-4433-87c0-68b6b72699c7 8388608 UnknownFS
[23:41:27][Information] MODEM_FSG 5099e138-afa9-41d3-8abb-c68035ad47f6 638ff8e2-22c9-e33b-8f5d-0e81686a68cb 1572864 UnknownFS
[23:41:27][Information] MODEM_FS1 9910fa9d-ab65-4526-b927-e58df39f9b28 ebbeadaf-22c9-e33b-8f5d-0e81686a68cb 1572864 UnknownFS
[23:41:27][Information] MODEM_FS2 150556a1-3bab-476b-af53-83ff93ddbbb1 0a288b1f-22c9-e33b-8f5d-0e81686a68cb 1572864 UnknownFS
[23:41:27][Information] MODEM_FSC 4f502076-cc1d-43c5-a184-fa699c7a0d9c 57b90a16-22c9-e33b-8f5d-0e81686a68cb 16384 UnknownFS
[23:41:27][Information] DDR 5f0b2af2-789f-40cf-94e8-1320148bebe3 20a0c19c-286a-42fa-9ce7-f64c3226a794 1048576 UnknownFS
[23:41:27][Information] SEC 099e9f73-faea-441d-85e2-f9968c91b17c 303e6ac3-af15-4c54-9e9b-d9a8fbecf401 131072 UnknownFS
[23:41:27][Information] APDP 71163b26-235f-4914-8544-a1847a31b48c e6e98da2-e22a-4d12-ab33-169e7deaa507 262144 UnknownFS
[23:41:27][Information] MSADP b95840e4-b514-4342-8b82-754dc8a857ae ed9e8101-05fa-46b7-82aa-8d58770d200b 262144 UnknownFS
[23:41:27][Information] DPO 4c406489-6462-4c2e-9a0a-10d5b26103b1 11406f35-1173-4869-807b-27df71802812 16384 UnknownFS
[23:41:27][Information] SSD 22c4850d-9f97-49a6-87cf-f8d756a758bd 2c86e742-745e-4fdd-bfd8-b6a7ac638772 16384 UnknownFS
[23:41:27][Information] UEFI_BS_NV 22cb258f-cf9a-4dd1-b92e-491ee81c5287 f0b4f48b-aeba-4ecf-9142-5dc30cdc3e77 262144 UnknownFS
[23:41:27][Information] UEFI_RT_NV 2c7d7649-6cc7-4d16-83c6-8f146bc056a9 6bb94537-7d1c-44d0-9dfe-6d77c011dbfc 262144 UnknownFS
[23:41:27][Information] LIMITS e3b63651-d608-496b-88ef-dcb38181b4cd 10a0c19c-516a-5444-5ce3-664c3226a794 16384 UnknownFS
[23:41:27][Information] SBL1 9c102374-ce77-4781-8985-171c2a2d0c02 dea0ba2c-cbdd-4805-b4f9-f428251c3e98 1048576 UnknownFS
[23:41:27][Information] PMIC 04ae7060-1f9e-4925-9a48-dbd1831a9d1f c00eef24-7709-43d6-9799-dd2b411e7a3c 524288 UnknownFS
[23:41:27][Information] DBI 4411540d-a939-4ac0-88b6-c2ea8aa0b183 d4e0d938-b7fa-48c1-9d21-bc5ed5c4b203 49152 UnknownFS
[23:41:27][Information] UEFI 44ac1467-53c3-4dc7-bfcc-81eb0a8e765f 400ffdcd-22e0-47e7-9a23-f16ed9382388 2097152 UnknownFS
[23:41:27][Information] RPM 7f3a5dfe-7498-4317-8a98-9b0c5b1ad5d9 098df793-d712-413d-9d4e-89d711772228 512000 UnknownFS
[23:41:27][Information] TZ 3301c7d0-0573-4c1c-85cb-9b4210690c86 a053aa7f-40b8-4b1c-ba08-2f68ac71a4f4 1048576 UnknownFS
[23:41:27][Information] HYP 48abdaa2-9ec0-494d-899c-65d4c1bed4f4 e1a6a689-0c8d-4cc6-b4e8-55a4320fbd8a 512000 UnknownFS
[23:41:27][Information] WINSECAPP 947daf14-a32e-4062-b8c2-03fef278dda6 69b4201f-a5ad-45eb-9f49-45b38ccdaef5 524288 UnknownFS
[23:41:27][Information] BACKUP_SBL1 2a58abff-53ca-49e2-8677-def56b4fc002 a3381699-350c-465e-bd5d-fa3ab901a39a 1048576 UnknownFS
[23:41:27][Information] BACKUP_PMIC 4dc10f89-3940-4697-bad7-1a463b6661f7 a3381699-350c-465e-bd5d-fa3ab901a39a 524288 UnknownFS
[23:41:27][Information] BACKUP_DBI c2fee666-c8c4-424e-af60-a12cf5dd00df a3381699-350c-465e-bd5d-fa3ab901a39a 49152 UnknownFS
[23:41:27][Information] BACKUP_UEFI 49f6985a-fb36-43e1-be4a-788959102f98 a3381699-350c-465e-bd5d-fa3ab901a39a 2097152 UnknownFS
[23:41:27][Information] BACKUP_RPM ea9dd527-e02f-4812-9de6-4ae3e9551907 a3381699-350c-465e-bd5d-fa3ab901a39a 512000 UnknownFS
[23:41:27][Information] BACKUP_TZ bda4ba75-9e6d-42fd-8aba-da5a5ba0b3a0 a3381699-350c-465e-bd5d-fa3ab901a39a 1048576 UnknownFS
[23:41:27][Information] BACKUP_HYP 22d9e40a-6eb0-49af-9bc5-f6251c4da1f0 a3381699-350c-465e-bd5d-fa3ab901a39a 512000 UnknownFS
[23:41:27][Information] BACKUP_WINSECAPP a6cf5077-df60-4ca1-8851-1b40756de446 a3381699-350c-465e-bd5d-fa3ab901a39a 524288 UnknownFS
[23:41:27][Information] BACKUP_TZAPPS 43d164f9-4ed5-4b50-9214-892382299072 a3381699-350c-465e-bd5d-fa3ab901a39a 16777216 UnknownFS

[23:41:27][Information] Building CBS Cabinet Files...

[23:47:04][Information] Creating package 259 of 259 - oem.halextensions.updateos
[23:47:04][Information] [===========================100%===========================]
[23:47:04][Information] Adding file 8 of 8 - Unknown (7)
[23:47:04][Information] [===========================100%===========================]

[23:47:04][Information] Cleaning up...


[23:47:04][Information] Building SPKG Cabinet Files...


[23:47:04][Information] Cleaning up...


[23:47:04][Information] Building Driver Files...


[23:47:04][Information] Cleaning up...

The operation completed successfully.
```

### Result

```batch
C:
|   OEMInput.xml
|
+---DriveE
|   \---build_e
|       \---TRWSDCIM003_image
|           \---ws
|               \---cityman_16887
|                   \---signed_spkgs
|                           MMO.BASE.Phone.EFIESP.cab
|                           MMO.BASE.Phone.MainOS.cab
|                           MMO.BASE.Phone.PLAT.cab
|                           MMO.BASE.Variant.EFIESP.cab
|                           MMO.BASE.Variant.MainOS.cab
|                           MMO.BASE.Variant.PLAT.cab
|                           MMO.CITYMAN_LTE_ROW.Customizations.EFIESP.cab
|                           MMO.CITYMAN_LTE_ROW.Customizations.MainOS.cab
|                           MMO.CITYMAN_LTE_ROW.Customizations.StaticApps.MainOS.cab
|                           MMO.DEVICE_CITYMAN_LTE_ROW.Phone.EFIESP.cab
|                           MMO.DEVICE_CITYMAN_LTE_ROW.Phone.MainOS.cab
|                           MMO.DEVICE_CITYMAN_LTE_ROW.Phone.PLAT.cab
|                           mmo.hyp.cab
|                           mmo.loader.sbl1.cab
|                           mmo.pmic.cab
|                           mmo.rpm.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_application.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_gsdb.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_imagetype.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_operator.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_prodconf.cab
|                           MMO.RuntimeCustomizations.RM-1085_12547_variant.cab
|                           MMO.RuntimeCustomizations.VersionInfo.spkg
|                           MMO.SOC_QC8994.Phone.EFIESP.cab
|                           MMO.SOC_QC8994.Phone.MainOS.cab
|                           MMO.SOC_QC8994.Phone.PLAT.cab
|                           mmo.tz.cab
|                           mmo.tzapps.cab
|                           mmo.uefi.cab
|                           mmo.winsecapp.cab
|                           oem.halextensions.updateos.cab
|
\---UNC
    \---mmrddfs
        \---tree
            \---wpbic
                \---th
                    \---plat
                        \---AK
                            \---10586.13169_dev12
                                \---Program Files
                                    \---Windows Kits
                                        \---10
                                            \---MSPackages
                                                +---Merged
                                                |   \---arm
                                                |       \---fre
                                                |               Microsoft.EFIESP.Production.cab
                                                |               Microsoft.MainOS.Production.cab
                                                |               Microsoft.MainOS.Production_Lang_af-ZA.cab
                                                |               Microsoft.MainOS.Production_Lang_am-ET.cab
                                                |               Microsoft.MainOS.Production_Lang_ar-SA.cab
                                                |               Microsoft.MainOS.Production_Lang_az-Latn-AZ.cab
                                                |               Microsoft.MainOS.Production_Lang_be-BY.cab
                                                |               Microsoft.MainOS.Production_Lang_bg-BG.cab
                                                |               Microsoft.MainOS.Production_Lang_bn-BD.cab
                                                |               Microsoft.MainOS.Production_Lang_ca-ES.cab
                                                |               Microsoft.MainOS.Production_Lang_cs-CZ.cab
                                                |               Microsoft.MainOS.Production_Lang_da-DK.cab
                                                |               Microsoft.MainOS.Production_Lang_de-DE.cab
                                                |               Microsoft.MainOS.Production_Lang_el-GR.cab
                                                |               Microsoft.MainOS.Production_Lang_en-GB.cab
                                                |               Microsoft.MainOS.Production_Lang_en-US.cab
                                                |               Microsoft.MainOS.Production_Lang_es-ES.cab
                                                |               Microsoft.MainOS.Production_Lang_es-MX.cab
                                                |               Microsoft.MainOS.Production_Lang_et-EE.cab
                                                |               Microsoft.MainOS.Production_Lang_eu-ES.cab
                                                |               Microsoft.MainOS.Production_Lang_fa-IR.cab
                                                |               Microsoft.MainOS.Production_Lang_fi-FI.cab
                                                |               Microsoft.MainOS.Production_Lang_fil-PH.cab
                                                |               Microsoft.MainOS.Production_Lang_fr-CA.cab
                                                |               Microsoft.MainOS.Production_Lang_fr-FR.cab
                                                |               Microsoft.MainOS.Production_Lang_gl-ES.cab
                                                |               Microsoft.MainOS.Production_Lang_ha-Latn-NG.cab
                                                |               Microsoft.MainOS.Production_Lang_he-IL.cab
                                                |               Microsoft.MainOS.Production_Lang_hi-IN.cab
                                                |               Microsoft.MainOS.Production_Lang_hr-HR.cab
                                                |               Microsoft.MainOS.Production_Lang_hu-HU.cab
                                                |               Microsoft.MainOS.Production_Lang_id-ID.cab
                                                |               Microsoft.MainOS.Production_Lang_is-IS.cab
                                                |               Microsoft.MainOS.Production_Lang_it-IT.cab
                                                |               Microsoft.MainOS.Production_Lang_ja-JP.cab
                                                |               Microsoft.MainOS.Production_Lang_kk-KZ.cab
                                                |               Microsoft.MainOS.Production_Lang_km-KH.cab
                                                |               Microsoft.MainOS.Production_Lang_kn-IN.cab
                                                |               Microsoft.MainOS.Production_Lang_ko-KR.cab
                                                |               Microsoft.MainOS.Production_Lang_lo-LA.cab
                                                |               Microsoft.MainOS.Production_Lang_lt-LT.cab
                                                |               Microsoft.MainOS.Production_Lang_lv-LV.cab
                                                |               Microsoft.MainOS.Production_Lang_mk-MK.cab
                                                |               Microsoft.MainOS.Production_Lang_ml-IN.cab
                                                |               Microsoft.MainOS.Production_Lang_ms-MY.cab
                                                |               Microsoft.MainOS.Production_Lang_nb-NO.cab
                                                |               Microsoft.MainOS.Production_Lang_nl-NL.cab
                                                |               Microsoft.MainOS.Production_Lang_pl-PL.cab
                                                |               Microsoft.MainOS.Production_Lang_pt-BR.cab
                                                |               Microsoft.MainOS.Production_Lang_pt-PT.cab
                                                |               Microsoft.MainOS.Production_Lang_ro-RO.cab
                                                |               Microsoft.MainOS.Production_Lang_ru-RU.cab
                                                |               Microsoft.MainOS.Production_Lang_sk-SK.cab
                                                |               Microsoft.MainOS.Production_Lang_sl-SI.cab
                                                |               Microsoft.MainOS.Production_Lang_sq-AL.cab
                                                |               Microsoft.MainOS.Production_Lang_sr-Latn-RS.cab
                                                |               Microsoft.MainOS.Production_Lang_sv-SE.cab
                                                |               Microsoft.MainOS.Production_Lang_sw-KE.cab
                                                |               Microsoft.MainOS.Production_Lang_ta-IN.cab
                                                |               Microsoft.MainOS.Production_Lang_te-IN.cab
                                                |               Microsoft.MainOS.Production_Lang_th-TH.cab
                                                |               Microsoft.MainOS.Production_Lang_tr-TR.cab
                                                |               Microsoft.MainOS.Production_Lang_uk-UA.cab
                                                |               Microsoft.MainOS.Production_Lang_uz-Latn-UZ.cab
                                                |               Microsoft.MainOS.Production_Lang_vi-VN.cab
                                                |               Microsoft.MainOS.Production_Lang_zh-CN.cab
                                                |               Microsoft.MainOS.Production_Lang_zh-TW.cab
                                                |               Microsoft.MainOS.Production_Res_1440x2560.cab
                                                |               Microsoft.MS_16GBFeaturesOnSystem.MainOS.cab
                                                |               Microsoft.MS_BOOTSEQUENCE_RETAIL.EFIESP.cab
                                                |               Microsoft.MS_BOOTSEQUENCE_RETAIL.MainOS.cab
                                                |               Microsoft.MS_COMMSENHANCEMENTGLOBAL.MainOS.cab
                                                |               Microsoft.MS_COMMSMESSAGINGGLOBAL.MainOS.cab
                                                |               Microsoft.MS_DOCKING.MainOS.cab
                                                |               Microsoft.MS_FACEBOOK.MainOS.cab
                                                |               Microsoft.MS_NAVIGATIONBAR.MainOS.cab
                                                |               Microsoft.MS_OPTIMIZED_BOOT.MainOS.cab
                                                |               Microsoft.MS_RCS_FEATURE_PACK.MainOS.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_DE-DE.Data.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_DE-DE.MainOS.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_EN-US.Data.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_EN-US.MainOS.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_FR-FR.Data.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_FR-FR.MainOS.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_IT-IT.Data.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_IT-IT.MainOS.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_NEUTRAL.Data.cab
                                                |               Microsoft.MS_RETAILDEMOCONTENT_NEUTRAL.MainOS.cab
                                                |               Microsoft.MS_SKYPE.MainOS.cab
                                                |               Microsoft.MS_SOCPRODTEST_HSTI.MainOS.cab
                                                |               Microsoft.MS_STANDARD_FEATURE_1.MainOS.cab
                                                |               Microsoft.PhoneFM.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_af-ZA.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_am-ET.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ar-SA.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_az-Latn-AZ.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_be-BY.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_bg-BG.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_bn-BD.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ca-ES.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_cs-CZ.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_da-DK.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_de-DE.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_el-GR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_en-GB.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_en-US.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_es-ES.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_es-MX.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_et-EE.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_eu-ES.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_fa-IR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_fi-FI.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_fil-PH.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_fr-CA.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_fr-FR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_gl-ES.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ha-Latn-NG.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_he-IL.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_hi-IN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_hr-HR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_hu-HU.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_id-ID.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_is-IS.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_it-IT.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ja-JP.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_kk-KZ.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_km-KH.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_kn-IN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ko-KR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_lo-LA.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_lt-LT.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_lv-LV.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_mk-MK.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ml-IN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ms-MY.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_nb-NO.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_nl-NL.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_pl-PL.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_pt-BR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_pt-PT.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ro-RO.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ru-RU.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sk-SK.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sl-SI.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sq-AL.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sr-Latn-RS.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sv-SE.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_sw-KE.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_ta-IN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_te-IN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_th-TH.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_tr-TR.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_uk-UA.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_uz-Latn-UZ.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_vi-VN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_zh-CN.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Lang_zh-TW.cab
                                                |               Microsoft.PRERELEASE_PROTECTED.MainOS_Res_1440x2560.cab
                                                |               Microsoft.RELEASE_PRODUCTION.EFIESP.cab
                                                |               Microsoft.RELEASE_PRODUCTION.MainOS.cab
                                                |               Microsoft.RELEASE_PRODUCTION.UpdateOS.cab
                                                |               Microsoft.SOC_QC8994.MainOS.cab
                                                |               Microsoft.UpdateOS.Production.cab
                                                |
                                                +---mobilecore
                                                |   \---ARM
                                                |       \---fre
                                                |               microsoft.mobilecore.prod.efiesp.cab
                                                |               microsoft.mobilecore.prod.mainos.cab
                                                |               microsoft.mobilecore.updateos.cab
                                                |
                                                \---retail
                                                    \---ARM
                                                        \---fre
                                                                Microsoft.Input.mtf_Lang_af-ZA.cab
                                                                Microsoft.Input.mtf_Lang_ar-SA.cab
                                                                Microsoft.Input.mtf_Lang_az-Latn-AZ.cab
                                                                Microsoft.Input.mtf_Lang_bg-BG.cab
                                                                Microsoft.Input.mtf_Lang_bn-BD.cab
                                                                Microsoft.Input.mtf_Lang_ca-ES.cab
                                                                Microsoft.Input.mtf_Lang_cs-CZ.cab
                                                                Microsoft.Input.mtf_Lang_da-DK.cab
                                                                Microsoft.Input.mtf_Lang_de-DE.cab
                                                                Microsoft.Input.mtf_Lang_el-GR.cab
                                                                Microsoft.Input.mtf_Lang_en-GB.cab
                                                                Microsoft.Input.mtf_Lang_en-IN.cab
                                                                Microsoft.Input.mtf_Lang_en-US.cab
                                                                Microsoft.Input.mtf_Lang_es-ES.cab
                                                                Microsoft.Input.mtf_Lang_es-MX.cab
                                                                Microsoft.Input.mtf_Lang_et-EE.cab
                                                                Microsoft.Input.mtf_Lang_eu-ES.cab
                                                                Microsoft.Input.mtf_Lang_fa-IR.cab
                                                                Microsoft.Input.mtf_Lang_fi-FI.cab
                                                                Microsoft.Input.mtf_Lang_fr-CA.cab
                                                                Microsoft.Input.mtf_Lang_fr-CH.cab
                                                                Microsoft.Input.mtf_Lang_fr-FR.cab
                                                                Microsoft.Input.mtf_Lang_gl-ES.cab
                                                                Microsoft.Input.mtf_Lang_ha-Latn-NG.cab
                                                                Microsoft.Input.mtf_Lang_hi-IN.cab
                                                                Microsoft.Input.mtf_Lang_hr-HR.cab
                                                                Microsoft.Input.mtf_Lang_hu-HU.cab
                                                                Microsoft.Input.mtf_Lang_hy-AM.cab
                                                                Microsoft.Input.mtf_Lang_id-ID.cab
                                                                Microsoft.Input.mtf_Lang_it-IT.cab
                                                                Microsoft.Input.mtf_Lang_ja-JP.cab
                                                                Microsoft.Input.mtf_Lang_kk-KZ.cab
                                                                Microsoft.Input.mtf_Lang_ko-KR.cab
                                                                Microsoft.Input.mtf_Lang_lt-LT.cab
                                                                Microsoft.Input.mtf_Lang_lv-LV.cab
                                                                Microsoft.Input.mtf_Lang_mk-MK.cab
                                                                Microsoft.Input.mtf_Lang_ms-MY.cab
                                                                Microsoft.Input.mtf_Lang_nb-NO.cab
                                                                Microsoft.Input.mtf_Lang_nl-BE.cab
                                                                Microsoft.Input.mtf_Lang_nl-NL.cab
                                                                Microsoft.Input.mtf_Lang_pl-PL.cab
                                                                Microsoft.Input.mtf_Lang_pt-BR.cab
                                                                Microsoft.Input.mtf_Lang_pt-PT.cab
                                                                Microsoft.Input.mtf_Lang_ro-RO.cab
                                                                Microsoft.Input.mtf_Lang_ru-RU.cab
                                                                Microsoft.Input.mtf_Lang_sk-SK.cab
                                                                Microsoft.Input.mtf_Lang_sl-SI.cab
                                                                Microsoft.Input.mtf_Lang_sq-AL.cab
                                                                Microsoft.Input.mtf_Lang_sr-Latn-RS.cab
                                                                Microsoft.Input.mtf_Lang_sv-SE.cab
                                                                Microsoft.Input.mtf_Lang_sw-KE.cab
                                                                Microsoft.Input.mtf_Lang_tr-TR.cab
                                                                Microsoft.Input.mtf_Lang_uk-UA.cab
                                                                Microsoft.Input.mtf_Lang_uz-Latn-UZ.cab
                                                                Microsoft.Input.mtf_Lang_vi-VN.cab
                                                                Microsoft.Input.mtf_Lang_zh-CN.cab
                                                                Microsoft.Input.mtf_Lang_zh-HK.cab
                                                                Microsoft.Input.mtf_Lang_zh-TW.cab
                                                                Microsoft.Speech.Data_Lang_de-DE.cab
                                                                Microsoft.Speech.Data_Lang_en-US.cab
                                                                Microsoft.Speech.Data_Lang_it-IT.cab
```

## Demo

https://github.com/user-attachments/assets/2c57f08e-34f8-46c5-81bd-8e93fa504b11
