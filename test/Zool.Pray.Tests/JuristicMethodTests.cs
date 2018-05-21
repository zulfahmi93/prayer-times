using Xunit;


namespace Zool.Pray.Tests
{
    public class JuristicMethodTests
    {
        [Fact(DisplayName = "Test set JuristicMethod preset to Hanafi.")]
        public void TestSetPresetHanafi()
        {
            var method = new JuristicMethod();
            method.SetJuristicMethodPreset(JuristicMethodPreset.Hanafi);

            Assert.Equal(JuristicMethodPreset.Hanafi, method.Preset);
            Assert.Equal(2, method.TimeOfShadow);
            Assert.Equal(JuristicMethodPreset.Hanafi, method.GetJuristicMethodPreset());
        }

        [Fact(DisplayName = "Test set JuristicMethod preset to Standard.")]
        public void TestSetPresetStandard()
        {
            var method = new JuristicMethod();
            method.SetJuristicMethodPreset(JuristicMethodPreset.Standard);

            Assert.Equal(JuristicMethodPreset.Standard, method.Preset);
            Assert.Equal(1, method.TimeOfShadow);
            Assert.Equal(JuristicMethodPreset.Standard, method.GetJuristicMethodPreset());
        }
    }
}
