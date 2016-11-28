using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ControleAtividades.Models
{
    public class Atividade
    {
        private List<Atividade_mdl> _ListaAtividades = new List<Atividade_mdl>();
        private String Erro;
        private String conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Users\elton ramalho\Documents\Visual Studio 2015\Projects\ControleAtividades\ControleAtividades\obj\Debug\Academicos.accdb";
        OleDbConnection conn = null;

        public Atividade()
        {


        }

        public Boolean criaAtividade(Atividade_mdl _Atividade_mdl)
        {
            try
            {
                conn = new OleDbConnection(conexao);
                String sql = "INSERT INTO TAREFAS (TIPOATIVIDADE,DESCRICAO,DATAPREVISTA,ENTREGUE )" +
                             "VALUES( '" + _Atividade_mdl.tipoAtividade.ToString() + "'," +
                                        "'" + _Atividade_mdl.descricao.ToString() + "'," +
                                         "'"+_Atividade_mdl.dataEntrega.ToString() + "'," +
                                          _Atividade_mdl.status.ToString() + ")";

                conn = new OleDbConnection(conexao);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Erro = "Erro: " + e.Message;
                return false;
            }
        }

        public Boolean alteraAtividade(Atividade_mdl _Atividade_mdl)
        {
            try
            {
                conn = new OleDbConnection(conexao);
                String sql = "UPDATE TAREFAS " +
                                "SET TIPOATIVIDADE = " + _Atividade_mdl.tipoAtividade.ToString() +
                                    ", DESCRICAO = " + _Atividade_mdl.descricao.ToString() +
                                    ", DATAPREVISTA = " + _Atividade_mdl.dataEntrega.ToString() +
                                    ", ENTREGUE = " + _Atividade_mdl.status.ToString() +
                              "WHERE ID=" + _Atividade_mdl.id.ToString() + ";";

                conn = new OleDbConnection(conexao);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Erro = "Erro: " + e.Message;
                return false;
            }
        }

        public Boolean apagaAtividade(Atividade_mdl _Atividade_mdl)
        {
            try
            { 
            conn = new OleDbConnection(conexao);
            String sql = "DELETE FROM TAREFAS WHERE ID=" + _Atividade_mdl.id.ToString() + ";";

            conn = new OleDbConnection(conexao);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
            }
            catch (Exception e)
            {
                Erro = "Erro: " + e.Message;
                return false;
            }
        }

        public List<Atividade_mdl> listarAtividades()
        {

            _ListaAtividades.Clear();
            try
            {                
                String sql = "SELECT ID, TIPOATIVIDADE, DESCRICAO, DATAPREVISTA, ENTREGUE FROM TAREFAS ORDER BY DATAPREVISTA DESC;";

                conn = new OleDbConnection(conexao);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Int32 ID = (Int32)reader.GetValue(0);
                    String TIPOATIVIDADE = reader.GetString(1);
                    String DESCRICAO = reader.GetString(2);
                    DateTime DATAPREVISTA = (DateTime)reader.GetValue(3);
                    Boolean ENTREGUE = (bool)reader.GetValue(4);

                    _ListaAtividades.Add(new Atividade_mdl((Int32)reader.GetValue(0), 
                                                          reader.GetString(1), 
                                                          reader.GetString(2), 
                                                          (DateTime)reader.GetValue(3), 
                                                          (bool)reader.GetValue(4)));
                }
            }
            catch(Exception e)
            {
                Erro = "Erro: " + e.Message;
                return null;
            }

            return _ListaAtividades;
        }

        public String obterErro()
        {
            return Erro;
        }
    }
}