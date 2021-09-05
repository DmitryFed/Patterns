using System;
using System.Text;

namespace Builder_Pattern
{

    public class Burger
    {

        public string Bread { get; set; }

        public string Chop { get; set; }

        public string Cheese { get; set; }

        public string Salad { get; set; }

        public string Pomodoro { get; set; }

        public string Cucumber { get; set; }

        public string Sause { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Bread != null)
                sb.Append(Bread + "\n");
            if (Chop != null)
                sb.Append(Chop +"\n");
            if (Cheese != null)
                sb.Append(Cheese + " \n");
            if (Sause != null)
                sb.Append("Соус:"+" "+ Sause + " \n");

            return sb.ToString();
        }

    }

   public abstract class BurgerBuilder
    {


        public Burger burger { get; private set; }

        public void CreateBurger()
        {

            burger = new Burger();

        }
        public virtual void SetBread() {

            Console.WriteLine("Булочка");
        }

        public virtual void SetChop()
        {
            Console.WriteLine("Котлета");
        
        }

        public abstract void SetCheese();

        public abstract void SetSalad();

        public abstract void SetSause();

    }



    public class HamburgerBuilder:BurgerBuilder
    {


        public override void SetSause()
        {
            this.burger.Sause = "Ketchup";

        }

        public override void SetCheese()
        {

        }

        public override void SetSalad()
        {
           
        }

    }


    public class CheeseBurgerBuilder : BurgerBuilder
    {
        public override void SetSause()
        {
            this.burger.Sause = "1000 islands";
        }

        public override void SetCheese()
        {
            this.burger.Cheese = "Сыр";

        }

        public override void SetSalad()
        {
            
            this.burger.Salad = "Лист салата"; 
           
        }


    }


    public class Cooker
    {

        public Burger Cook(BurgerBuilder burgerBuider)
        {

            burgerBuider.CreateBurger();

            burgerBuider.SetBread();

            burgerBuider.SetChop();

            burgerBuider.SetSause();

            burgerBuider.SetSalad();

            burgerBuider.SetCheese();

            return burgerBuider.burger;
        
        }

    
    }



    class Program
    {
        static void Main(string[] args)
        {

            Burger burger;

            CheeseBurgerBuilder cheese = new CheeseBurgerBuilder();

            Cooker cooker = new Cooker();

            burger = cooker.Cook(cheese);

            Console.WriteLine(burger.ToString());

        }
    }
}
