using System;

namespace ControleAtividades.Models
{
    public class Atividade_mdl
    {
        public Int32 id { get; set;}
        public String tipoAtividade { get; set; }
        public String descricao { get; set; }
        public DateTime dataEntrega { get; set; }
        public Boolean status { get; set; }

        public Atividade_mdl (Int32 _id,
                              String _tipoAtividade,
                              String _descricao,
                              DateTime _dataEntrega,
                              Boolean _status)        
        {
            id = _id;
            tipoAtividade =_tipoAtividade;
            descricao =_descricao;
            dataEntrega =_dataEntrega;
            status =_status;  
        }
    }
}