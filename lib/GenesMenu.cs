using UnityEngine;

namespace nim_qol
{
    internal sealed class GenesMenu : MonoBehaviour
    {
        private bool IsOpen = false;
        private Rect WindowRect = new(20, 20, 256, 0);

        private static KoboldGenes NewGenes = new();

        internal void Open()
        {
            IsOpen = true;
        }

        internal void Close()
        {
            IsOpen = false;
        }

        internal void Toggle()
        {
            IsOpen = !IsOpen;
        }

        internal void Draw()
        {
            if (IsOpen)
            {
                WindowRect = GUI.Window(-998, WindowRect, WindowFunction, "Gene Editor");
            }
        }

        internal void WindowFunction(int windowID)
        {
            var y = 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Max Energy:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.maxEnergy.ToString()), out NewGenes.maxEnergy);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Base Size:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.baseSize.ToString()), out NewGenes.baseSize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Fat:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.fatSize.ToString()), out NewGenes.fatSize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Balls Size:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.ballSize.ToString()), out NewGenes.ballSize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Dick Size:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.dickSize.ToString()), out NewGenes.dickSize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Breast Size:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.breastSize.ToString()), out NewGenes.breastSize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Belly Capacity:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.bellySize.ToString()), out NewGenes.bellySize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Metabolism:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.metabolizeCapacitySize.ToString()), out NewGenes.metabolizeCapacitySize);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Hue:");
            byte.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.hue.ToString()), out NewGenes.hue);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Clothing Hue:");
            byte.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.clothingHue.ToString()), out NewGenes.clothingHue);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Brightness:");
            byte.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.brightness.ToString()), out NewGenes.brightness);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Saturation:");
            byte.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.saturation.ToString()), out NewGenes.saturation);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Grab Count:");
            byte.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.grabCount.ToString()), out NewGenes.grabCount);
            y += 22;

            GUI.Label(new Rect(5, y, WindowRect.width / 2, 22), $"Dick Thickness:");
            float.TryParse(GUI.TextField(new Rect(WindowRect.width - 55, y, 50, 22), NewGenes.dickThickness.ToString()), out NewGenes.dickThickness);
            y += 22;

            if (GUI.Button(new Rect(5, y, WindowRect.width - 10, 22), "Set Genes"))
            {
                Plugin.GameState.Kobold.SetGenes(new KoboldGenes()
                {
                    maxEnergy = NewGenes.maxEnergy,
                    baseSize = NewGenes.baseSize,
                    fatSize = NewGenes.fatSize,
                    ballSize = NewGenes.ballSize,
                    dickSize = NewGenes.dickSize,
                    breastSize = NewGenes.breastSize,
                    bellySize = NewGenes.bellySize,
                    metabolizeCapacitySize = NewGenes.metabolizeCapacitySize,
                    hue = NewGenes.hue,
                    clothingHue = NewGenes.clothingHue,
                    brightness = NewGenes.brightness,
                    saturation = NewGenes.saturation,
                    dickEquip = Plugin.GameState.Kobold.GetGenes().dickEquip,
                    grabCount = NewGenes.grabCount,
                    dickThickness = NewGenes.dickThickness,
                    species = Plugin.GameState.Kobold.GetGenes().species
                });
            }
            y += 22;

            if (GUI.Button(new Rect(5, y, WindowRect.width - 10, 22), "Load Current Genes"))
            {
                var CurrentGenes = Plugin.GameState.Kobold.GetGenes();

                NewGenes = new KoboldGenes()
                {
                    maxEnergy = CurrentGenes.maxEnergy,
                    baseSize = CurrentGenes.baseSize,
                    fatSize = CurrentGenes.fatSize,
                    ballSize = CurrentGenes.ballSize,
                    dickSize = CurrentGenes.dickSize,
                    breastSize = CurrentGenes.breastSize,
                    bellySize = CurrentGenes.bellySize,
                    metabolizeCapacitySize = CurrentGenes.metabolizeCapacitySize,
                    hue = CurrentGenes.hue,
                    clothingHue = CurrentGenes.clothingHue,
                    brightness = CurrentGenes.brightness,
                    saturation = CurrentGenes.saturation,
                    dickEquip = CurrentGenes.dickEquip,
                    grabCount = CurrentGenes.grabCount,
                    dickThickness = CurrentGenes.dickThickness,
                    species = CurrentGenes.species
                };
            }
            y += 22;

            y += 5;
            WindowRect.height = y;

            GUI.DragWindow();
        }
    }
}