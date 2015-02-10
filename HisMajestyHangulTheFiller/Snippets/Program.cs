using System.Globalization;
using System.Linq;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable UnusedMember.Local
namespace Snippets
{
    public class Cvrči_cvrči_cvrčak_na_čvoru_crne_smrče
    {
        public void कोशिश_करने_वालों_की() { }
        public void Лулу_и_пътуването() { }
        public void De_la_capăt() { }
        public void Herz_schlägt_auch_im_Eis() { }
    }

    public class Cvrčiㅤcvrčiㅤcvrčakㅤnaㅤčvoruㅤcrneㅤsmrče
    {
        public void कोशिशㅤकरनेㅤवालोंㅤकी() { }
        public void Лулуㅤиㅤпътуването() { }
        public void Deㅤlaㅤcapăt() { }
        public void HerzㅤschlägtㅤauchㅤimㅤEis() { }
    }

    public class ValidCSharpIdentifier
    {
        UnicodeCategory[] validCharacterCategories = 
        {
            UnicodeCategory.UppercaseLetter,
            UnicodeCategory.LowercaseLetter,
            UnicodeCategory.TitlecaseLetter,
            UnicodeCategory.ModifierLetter,
            UnicodeCategory.OtherLetter,
            UnicodeCategory.LetterNumber,
            UnicodeCategory.DecimalDigitNumber,
            UnicodeCategory.ConnectorPunctuation,
            UnicodeCategory.NonSpacingMark,
            UnicodeCategory.Format
        };

        public bool IsValidCSharpIdentifierCharacter(char character)
        {
            return validCharacterCategories.Contains(char.GetUnicodeCategory(character));
        }
    }

    /*
    foreach Unicode character that IsValidCSharpIdentifierCharacter
        draw the character in black color on the white surface
        if the surface afterwards is all white
            yield the character
    */

    public class TheInvisibleCharacters
    {
        char[] theInvisibleCharacters =
        {
            '\u0559', '\u0951', '\u0952', '\u0A51', '\u0A75', '\u115F', '\u1160', '\u135F', '\u180B',
            '\u180C', '\u180D', '\u200B', '\u200C', '\u200D', '\u200E', '\u200F', '\u202A', '\u202B',
            '\u202C', '\u202D', '\u202E', '\u2060', '\u2061', '\u2062', '\u2063', '\u2064', '\u206A',
            '\u206B', '\u206C', '\u206D', '\u206E', '\u206F', '\u2D6F', '\u3164', '\uFE70', '\uFE72',
            '\uFE76', '\uFE78', '\uFE7C', '\uFE7E', '\uFEFF', '\uFFA0', '\uFFF9', '\uFFFA', '\uFFFB'
        };
    }
}
// ReSharper restore UnusedMember.Local
// ReSharper restore FieldCanBeMadeReadOnly.Local
// ReSharper restore InconsistentNaming