namespace _5thLabComponents
{
    class PromoCodeDiscount : PromoCodeDecorator
    {
        public override string GetEffect()
        {
            return "скидка" + (PromoCode != null ? (" + " + PromoCode.GetEffect()) : "");
        }
    }
}
