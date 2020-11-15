namespace _5thLabComponents
{
    class PromoCodeDeferredDiscount : PromoCodeDecorator
    {
        public override string GetEffect()
        {
            return "отложенная скидка" + (PromoCode != null ? (" + " + PromoCode.GetEffect()) : "");
        }
    }
}
