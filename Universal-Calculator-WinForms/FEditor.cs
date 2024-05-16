namespace Universal_Calculator_WinForms
{
    class FEditor : AEditor//класс редактор дроби
    {
        private PEditor _numPEditor = new PEditor();
        private PEditor _dnomPEditor = new PEditor();
        private bool isFrac;

        public override string DoEdit(int operation)
        {
            if (operation == 20 || operation == 19)
            {
                _dnomPEditor.DoEdit(operation);
                _numPEditor.DoEdit(operation);
                isFrac = false;
            }
            else
            {
                if (!isFrac)
                {
                    if (operation != 55) _numPEditor.DoEdit(operation);
                    else isFrac = true;
                }
                else
                {
                    if (operation != 55) _dnomPEditor.DoEdit(operation);
                    else isFrac = false;
                }
            }

            if (_dnomPEditor.Number == "0" && !isFrac) return _numPEditor.Number;
            else if (_dnomPEditor.Number == "0" && isFrac) return _numPEditor.Number + "/";
            return _numPEditor.Number + "/" + _dnomPEditor.Number;
        }
    }
}
