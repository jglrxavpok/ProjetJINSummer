using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace JINSummer.PostProcess {
    [Serializable]
    [PostProcess(typeof(CRTRenderer), PostProcessEvent.AfterStack, "Custom/CRT")]
    public sealed class CRT : PostProcessEffectSettings
    {
        [Range(0f, 1f), Tooltip("CRT effect intensity.")]
        public FloatParameter blend = new FloatParameter { value = 0.5f };
        
        [Range(0f, 100.0f), Tooltip("CRT band height multiplier.")]
        public FloatParameter bandMultiplier = new FloatParameter { value = 1.0f };
        
        [Range(-100.0f, 100.0f), Tooltip("CRT band scrolling speed.")]
        public FloatParameter scrollSpeed = new FloatParameter { value = 0.0f };
    }

    public sealed class CRTRenderer : PostProcessEffectRenderer<CRT>
    {
        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/CRT"));
            sheet.properties.SetFloat("_Blend", settings.blend);
            sheet.properties.SetFloat("_BandHeightMultiplier", settings.bandMultiplier);
            sheet.properties.SetFloat("_BandScrollSpeed", settings.scrollSpeed);
            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
   
}