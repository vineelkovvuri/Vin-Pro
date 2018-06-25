using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Search_2006
{
    partial class AboutSearch2006 : Form
    {
        public AboutSearch2006()
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            this.Text = String.Format( "About {0}" , AssemblyTitle );
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format( "Version {0}" , AssemblyVersion );
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object [] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ) , false );
                // If there is at least one Title attribute
                if ( attributes.Length > 0 )
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = ( AssemblyTitleAttribute )attributes [0];
                    // If it is not an empty string, return it
                    if ( titleAttribute.Title != "" )
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object [] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ) , false );
                // If there aren't any Description attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Description attribute, return its value
                return ( ( AssemblyDescriptionAttribute )attributes [0] ).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object [] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ) , false );
                // If there aren't any Product attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Product attribute, return its value
                return ( ( AssemblyProductAttribute )attributes [0] ).Product;
            }
        }

  

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object [] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCompanyAttribute ) , false );
                // If there aren't any Company attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Company attribute, return its value
                return ( ( AssemblyCompanyAttribute )attributes [0] ).Company;
            }
        }
        #endregion

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

       

      
    }
}
