using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValiadCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEndercoViaCEP(cep);
                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço:{2} {3} {0},{1} ", end.Localidade, end.Uf, end.Lougradouro, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO CRÍTICO", "O endereço não foi encontrado para o CEP: " + cep, "OK");
                    }

                    
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message,"OK");
                }

            }
           
        }

        private Boolean isValiadCEP(string cep)
        {
            Boolean Valiad = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter 8 caracteres.","OK" );
                Valiad = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve ser composto apensa por numeros.", "OK");
                Valiad = false;
            }
            return Valiad ;

        }
    }
}
