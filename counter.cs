using System.Text;

namespace Helpers {
    public class Counter {
        private bool _caseInSensitive;
        private bool _alphaOnly;
        private Dictionary<char, int> _charDict = [];

        public Counter(bool caseInSensitive = true, bool alphaOnly = true) {
            _caseInSensitive = caseInSensitive;
            _alphaOnly = alphaOnly;
        }
        public void Add(string str) {
            char[] charArr = str.ToCharArray();
            Add(charArr);
        }
        public void Add(char[] charArr) {
            if (_caseInSensitive) {
                charArr = ToLower(charArr);
            }
            foreach (char c in charArr) {
                if (_alphaOnly && !Char.IsLetter(c)) {
                    continue;
                }
                if (!_charDict.TryAdd(c, 1)) {
                    _charDict[c] += 1;
                }
            }
        }
        public StringBuilder ToSB() {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<char, int> kvp in _charDict) {
                sb.Append($"'{kvp.Key}': {kvp.Value}\n");
            }
            return sb;
        }
        private char[] ToLower(char[] charArr) {
            return new String(charArr).ToLower().ToCharArray();
        }
    }
}