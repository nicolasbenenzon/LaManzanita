using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manzanita
{
    public static class GameData
    {
        public const int VALUE_CEREZA = 2;
        public const int VALUE_APPLE = 4;
        public const int VALUE_ORANGE = 6;
        public const int VALUE_PERA = 6;
        public const int VALUE_ANANA = 8;
        public const int VALUE_BANANA = 10;
        public const int VALUE_STAR = 30;
        public const int VALUE_BAR50 = 50;
        public const int VALUE_BAR100 = 100;
        public const int COINS_SILVER = 2;
        public const int COINS_GOLD = 4;
        public static int goldCoins = 0;
        public static int silverCoins = 0;
        public static int money = 0;
        public static int cantNuevoTiro = 0;
        public static int cantWinCereza = 0, cantWinApple = 0, cantWinOrange = 0, cantWinPera = 0, cantWinBanana = 0, cantWinAnana = 0, cantWinStar = 0, cantWinBAR50 = 0, cantWinBAR100 = 0;
        public static int cantLosCereza = 0, cantLosApple = 0, cantLosOrange = 0, cantLosPera = 0, cantLosAnana = 0, cantLosBanana = 0, cantLosStar = 0, cantLosBAR50 = 0, cantLosBAR100 = 0;
        public static int cantWinGoldCoinsCereza = 0, cantWinGoldCoinsApple = 0, cantWinGoldCoinsOrange = 0, cantWinGoldCoinsPera = 0, cantWinGoldCoinsAnana = 0, cantWinGoldCoinsBanana = 0, cantWinGoldCoinsStar = 0, cantWinGoldCoinsBAR50 = 0, cantWinGoldCoinsBAR100 = 0;
        public static int cantWinSilverCoinsCereza = 0, cantWinSilverCoinsApple = 0, cantWinSilverCoinsOrange = 0, cantWinSilverCoinsPera = 0, cantWinSilverCoinsAnana = 0, cantWinSilverCoinsBanana = 0, cantWinSilverCoinsStar = 0, cantWinSilverCoinsBAR50 = 0, cantWinSilverCoinsBAR100 = 0;
        public static int typeCoin = 0;
        public static int insertedGoldCoins = 0;
        public static int insertedSilverCoins = 0;
        public static int insertedRealCoins = 0;
        public static int finallyWinPos = 0;
        public static bool alreadyBetted = false;
        public static int lightTurn = 1;
        public static string nameAccount = "";
        public static int insertedCoinsCereza = 0, insertedCoinsApple = 0, insertedCoinsOrange = 0, insertedCoinsBanana = 0, insertedCoinsAnana = 0, insertedCoinsPera = 0, insertedCoinsStar = 0, insertedCoinsBAR50 = 0, insertedCoinsBAR100 = 0;
    }
}
