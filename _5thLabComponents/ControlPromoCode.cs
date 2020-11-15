using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _5thLabComponents
{
    public partial class ControlPromoCode : UserControl
    {
        private event EventHandler listBoxSelectedElementChange;

        private PromoCode promoCode;

        public string Effect
        {
            get
            {
                return promoCode != null ? promoCode.GetEffect() : "нет";
            }
        }

        public ControlPromoCode()
        {
            InitializeComponent();

            List<string> list = new List<string>();
            list.Add("Скидка");
            list.Add("Отложенная скидка");
            list.Add("Подарок");
            listBox.Items.AddRange(list.ToArray());

            listBox.SelectionMode = SelectionMode.MultiExtended;
            listBox.SelectedIndexChanged += (sender, e)
                => { listBoxSelectedElementChange?.Invoke(sender, e); };
        }

        public event EventHandler ListBoxSelectedElementChange
        {
            add { listBoxSelectedElementChange += value; }
            remove { listBoxSelectedElementChange -= value; }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PromoCodeDecorator pc = null;

            foreach (string item in listBox.SelectedItems)
            {
                if (pc == null)
                {
                    pc = ParsePromoCodeFromString(item);
                }
                else
                {
                    PromoCodeDecorator old = pc;
                    pc = ParsePromoCodeFromString(item);
                    pc.PromoCode = old;
                }
            }

            promoCode = pc;
        }

        private PromoCodeDecorator ParsePromoCodeFromString(string str)
        {
            switch (str)
            {
                case "Скидка":
                    return new PromoCodeDiscount();
                case "Отложенная скидка":
                    return new PromoCodeDeferredDiscount();
                case "Подарок":
                    return new PromoCodeGift();
                default:
                    throw new ArgumentException("Неизвестный тип промокода " + str);
            }
        }
    }
}
