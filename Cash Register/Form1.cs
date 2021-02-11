using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Cash_Register
{
    public partial class Form1 : Form
    {
        //Global Variables
        SoundPlayer menuSelect;
        SoundPlayer sale;
        SoundPlayer printerNoise;
        SoundPlayer errorNoise;

        double swordPrice = 5.03;
        double chestplatePrice = 10.75;
        double hammerPrice = 3.37;

        int orderNumber = 1;
        int swordAmount;
        int chestplateAmount;
        int hammerAmount;

        double tenderedAmount;
        double tax = 0.13;
        double totalPrice;
        double subTotal;
        double taxPrice;
        double change;

        private int originalWidth;
        private int originalHeight;

        public Form1()
        {
            InitializeComponent();

            //This code is to Hide the image at the start
            receiptLabel.Hide();

            //This code is to make Soundplayers
            menuSelect = new SoundPlayer(Properties.Resources.menu_select);
            sale = new SoundPlayer(Properties.Resources.Print_Receipt);
            printerNoise = new SoundPlayer(Properties.Resources.Printer_Noise);
            errorNoise = new SoundPlayer(Properties.Resources.Error_Noise);

            originalWidth = this.Width;
            originalHeight = this.Height;

            printReceiptButton.Hide();
        }

        private void calculateTotalButton_Click(object sender, EventArgs e)
        {
            menuSelect.Play();

            try
            {
                //This code is to convert strings to a int
                swordAmount = Convert.ToInt32(numberOfSwordsTextbox.Text);
                chestplateAmount = Convert.ToInt32(numberOfChestplatesTextbox.Text);
                hammerAmount = Convert.ToInt32(numberOfHammersTextbox.Text);

                //This code is to calculate the subTotal, taxPrice and totalPrice
                subTotal = (swordAmount * swordPrice) + (chestplateAmount * chestplatePrice) + (hammerAmount * hammerPrice);
                subTotalNumLabel.Text = $"{subTotal.ToString("C")}";

                taxPrice = subTotal * tax;
                taxNumLabel.Text = $"{taxPrice.ToString("C")}";


                totalPrice = taxPrice + subTotal;
                totalNumLabel.Text = $"{totalPrice.ToString("C")}";
            }
            catch
            {
                //This code is so the program doesnt crash
                antiCrashLabel.Text = "Please insert amount and use numbers";
                
                errorNoise.Play();

                antiCrashLabel.Show();

                antiCrashLabel.ForeColor = Color.Red;
                antiCrashLabel.BackColor = Color.Transparent;
                Refresh();
                Thread.Sleep(100);

                antiCrashLabel.ForeColor = Color.White;
                antiCrashLabel.BackColor = Color.Red;
                Refresh();
                Thread.Sleep(100);

                antiCrashLabel.ForeColor = Color.Red;
                antiCrashLabel.BackColor = Color.Transparent;
                Refresh();
                Thread.Sleep(800);

                antiCrashLabel.Hide();
            }

        }


        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            sale.Play();
            printReceiptButton.Show();
            try
            {
                //This code is to calculate the change
                tenderedAmount = Convert.ToInt32(tenderedTextbox.Text);
                change = tenderedAmount - totalPrice;

                changeNumLabel.Text = $"{change.ToString("C")}";
            }
            catch
            {
                //This code is so the program doesnt crash
                antiCrashLabel.Text = "Please ender tender amount in numbers";

                errorNoise.Play();
               
                antiCrashLabel.Show();

                antiCrashLabel.ForeColor = Color.Red;
                antiCrashLabel.BackColor = Color.Transparent;
                Refresh();
                Thread.Sleep(100);

                antiCrashLabel.ForeColor = Color.White;
                antiCrashLabel.BackColor = Color.Red;
                Refresh();
                Thread.Sleep(100);

                antiCrashLabel.ForeColor = Color.Red;
                antiCrashLabel.BackColor = Color.Transparent;
                Refresh();
                Thread.Sleep(800);

                antiCrashLabel.Hide();
            }
        }

        private void printReceiptButton_Click(object sender, EventArgs e)
        {
            printerNoise.Play();
            this.Width = 525;



            //This code is to print the receipt
            receiptLabel.Show();
            receiptLabel.Text = "          Hunters Blacksmith";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n\n Order Number {orderNumber++}";
            Refresh();
            Thread.Sleep(100);
            
            receiptLabel.Text += "\n February 10, 2021";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n\n Swords                  x{swordAmount}  @ {swordPrice}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n Chestplates             x{chestplateAmount}  @ {chestplatePrice}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n Hammers                 x{hammerAmount}  @ {hammerPrice}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n\n Subtotal                     {subTotal.ToString("C")}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n Tax                          {taxPrice.ToString("C")}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n Total                        {totalPrice.ToString("C")}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n\n Tendered                     ${tenderedAmount}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n Change                       {change.ToString("C")}";
            Refresh();
            Thread.Sleep(100);

            receiptLabel.Text += $"\n\n          Have a nice day!";
            Refresh();
            Thread.Sleep(100);


        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            menuSelect.Play();
            this.Width = 275;
            printReceiptButton.Hide();

            //This code is to reset everything so its not the same receipt when everything says 0
            swordAmount = 0;
            chestplateAmount = 0;
            hammerAmount = 0;

            swordPrice = 0;
            chestplatePrice = 0;
            hammerPrice = 0;

            subTotal = 0;
            taxPrice = 0;
            totalPrice = 0;
            tenderedAmount = 0;
            change = 0;

            numberOfSwordsTextbox.Text = "0";
            numberOfChestplatesTextbox.Text = "0";
            numberOfHammersTextbox.Text = "0";
            tenderedTextbox.Text = "0";

            subTotalNumLabel.Text = "0";
            taxNumLabel.Text = "0";
            totalNumLabel.Text = "0";
            changeNumLabel.Text = "0";

            swordPrice = 5.03;
            chestplatePrice = 10.75;
            hammerPrice = 3.37;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //This code is to exit the application
            Application.Exit();
        }


        private void numberOfSwordsLabel_Click(object sender, EventArgs e)
        {
            //Added an easter egg
            numberOfSwordsLabel.Text = "https://www.youtube.com/watch?v=oHg5SJYRHA0";
            numberOfSwordsLabel.Font = new Font("consolas" , numberOfSwordsLabel.Font.Size);
            numberOfSwordsTextbox.Hide();
            Width = 350;
            Refresh();
            Thread.Sleep(1000);
            numberOfSwordsLabel.Text = "Number Of Swords";
            numberOfSwordsLabel.Font = new Font("Segoe Script", numberOfSwordsLabel.Font.Size);
            numberOfSwordsTextbox.Show();
            Width = 275;
        }
    }
}
