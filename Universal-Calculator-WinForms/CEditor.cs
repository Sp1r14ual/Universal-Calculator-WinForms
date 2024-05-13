namespace Universal_Calculator_WinForms
{
    class CEditor : AEditor// класс редактор комплексного числа
    {
        private PEditor _rePEditor = new PEditor();
        private PEditor _imPEditor = new PEditor();
        private bool isComplex = false;

        public override string DoEdit(int operation)
        {
            if (operation == 20 || operation == 19)
            {
                _rePEditor.DoEdit(operation);
                _imPEditor.DoEdit(operation);
                isComplex = false;
            }
            else
            {
                if (isComplex == false)
                {
                    if (operation != 55) _rePEditor.DoEdit(operation);
                    else isComplex = true;
                }
                else
                {
                    if (operation != 55) _imPEditor.DoEdit(operation);
                    else isComplex = false;
                }
            }

            if (_imPEditor.Number == "0" && !isComplex) return _rePEditor.Number;
            else if (_imPEditor.Number == "0" && isComplex) return _rePEditor.Number + "i";
            return _rePEditor.Number + "i" + _imPEditor.Number;
        }
    }
}
