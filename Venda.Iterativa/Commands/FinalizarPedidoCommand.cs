using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Venda.Iterativa.Classes;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.Commands
{
    internal class FinalizarPedidoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var vm = parameter as ReceberViewModel;
            //var pedido = vm.Pedido;

            // Número cartão
            if (vm.Pedido.NumeroCartao.ToString().Length == 0)
            {
                MessageBox.Show("Informe o número do cartão!");
                return;

            } else if(vm.Pedido.NumeroCartao.ToString().Length != 16)
            {
                MessageBox.Show("Quantidade inválida de caracteres do número do cartão!");
                return;
            }

            // Data validade
            if(vm.Pedido.DataValidade < DateTime.Today) 
            {
                MessageBox.Show("Seu cartão está vencido!");
                return;
            }

            // CVV
            if (vm.Pedido.CVV.ToString().Length == 0)
            {
                MessageBox.Show("Informe o CVV do cartão!");
                return;
            }

            if (vm.Pedido.CVV.ToString().Length != 4)
            {
                MessageBox.Show("Quantidade inválida de caracteres do CVV!");
                return;
            }

            MessageBox.Show("Compra reazlizada com sucesso!");
        }
    }
}
