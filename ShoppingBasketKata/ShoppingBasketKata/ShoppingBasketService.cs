﻿namespace ShoppingBasketKata;

public class ShoppingBasketService
{
    private readonly IShoppingBasketRepository shoppingBasketRepository;

    public ShoppingBasketService(IShoppingBasketRepository shoppingBasketRepository)
    {
        this.shoppingBasketRepository = shoppingBasketRepository;
    }

    public void AddItem(UserID userId, ProductID productId, int quantity) =>
        shoppingBasketRepository.Register(userId, productId, quantity);

    public Basket BasketFor(UserID userId) =>
        throw new NotImplementedException();
}

/*public class ShoppingBasketService {

        public void addItem(UserID userId, ProductID productId, int quantity) { }

        public <?> basketFor(UserID userId) { }

    }    */
