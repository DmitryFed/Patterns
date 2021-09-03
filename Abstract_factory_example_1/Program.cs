using System;

namespace Abstract_factory_example_1
{


    //Некий продукт 1
    abstract public class MessengerWidget
    {

        public abstract void Display();
   
    }


    // Реализация 1
  public  class TelegramWidget : MessengerWidget
    {
        public override void Display()
        {
            Console.WriteLine("Самолет");
        }

    }


    //Реализация 2
    public class WhatsAppWidget : MessengerWidget
    {
        public override void Display()
        {
            Console.WriteLine("Телефонная трубка");  
        }

    }


    //Некий продукт 2
    abstract public class MessengerSound{public abstract void Ring();}

    public class TelegramSound:MessengerSound
    {
        public override void Ring()
        {
            Console.WriteLine("Нота пианино");
        }
    }


    // Реализация
    public class WhatsAppSound : MessengerSound
    {
        public override void Ring()
        {
            Console.WriteLine("Колокольчик");
        }
    }

    //интерфейс фабрики
    abstract public class Messenger
    {
      public abstract MessengerSound CreateMessengerSound();
      public abstract MessengerWidget CreateMessengerWidget();
    
    }


    //фабрика
    public class TelegramMessenger : Messenger
    {

        public override TelegramSound CreateMessengerSound()
        {
            return new TelegramSound();
        }


        public override TelegramWidget CreateMessengerWidget()
        {
            return new TelegramWidget();
        }

    }


    //фабрика
    public class WhatsAppMessenger : Messenger
    {

        public override WhatsAppSound CreateMessengerSound()
        {
            return new WhatsAppSound();
        }


        public override WhatsAppWidget CreateMessengerWidget()
        {
            return new WhatsAppWidget();
        }

    }

    //Реализация абстрактной фабрики
    class messengerFactory
    {

        MessengerWidget widget;
        MessengerSound sound;
      public  messengerFactory(Messenger messenger)
        {
            widget = messenger.CreateMessengerWidget();
            sound = messenger.CreateMessengerSound();
        
        }

        public void DoSound()
        {
            sound.Ring();
        
        }

        public void DisplayWidget()
        {
            widget.Display();
        
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            messengerFactory factory = new messengerFactory(new TelegramMessenger());

            factory.DisplayWidget();

            factory.DoSound();
        }
    }
}
