namespace NossoERP.WebApi.Nuvem.Clinica.Pagination
{
    public class QueryStringParameters
    {
        const int maxPageSize = 10000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 100;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize)
                                ? maxPageSize : value;
            }
        }
        public int? id_empresa { get; set; }
        public int? id_colaborador { get; set; }
        public int? id_usuario { get; set; }
        public DateTime? data_inicial { get; set; }
        public DateTime? data_final { get; set; }
        public int? status { get; set; }
    }
}
