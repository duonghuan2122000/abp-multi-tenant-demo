﻿using Volo.Abp.Settings;

namespace Sora.AbpDemo.Settings;

public class AbpDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpDemoSettings.MySetting1));
    }
}
