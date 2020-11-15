namespace _5thLabComponents
{
    class PromoCodeGift : PromoCodeDecorator
    {
        public override string GetEffect()
        {
            return "подарок" + (PromoCode != null ? (" + " + PromoCode.GetEffect()) : "");
        }
    }
}
