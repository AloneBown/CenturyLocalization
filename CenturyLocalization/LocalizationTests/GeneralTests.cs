using CenturyLocalization;
using Xunit;

namespace LocalizationTests
{
	public class GeneralTests
	{
		[Fact]
		public void CultureInfoIsCorrect()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("en-US");

			Assert.Equal("en-US", local.CurrentLanguage.Name);
		}

		[Fact]
		public void GettingExistingStringAndDefaultEnglish()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("en-US");

			var result = local.GetText("unittest_onlyen");

			Assert.Equal("Ok", result);
		}

		[Fact]
		public void GetNonExistingFileLocaleReturnsEnglish()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("smj-SE");

			var result = local.GetText("unittest_onlyen");

			Assert.Equal("smj-SE", local.CurrentLanguage.Name);
			Assert.Equal("Ok", result);
		}

		[Fact]
		public void GetNonExistingStringReturnsNull()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("en-US");

			var result = local.GetText("unittest_DOESNTEXIST");

			Assert.Equal("String not found", result);
		}

		[Fact]
		public void GetOtherLocaleString()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("es-ES");

			var result = local.GetText("unittest_both");

			Assert.Equal("Ok_es", result);
		}

		[Fact]
		public void GetOtherLocaleStringDifferentCountry()
		{
			var local = new Localization();

			local.CurrentLanguage = new System.Globalization.CultureInfo("es-AR");

			var result = local.GetText("unittest_both");

			Assert.Equal("Ok_es", result);
		}


	}
}
