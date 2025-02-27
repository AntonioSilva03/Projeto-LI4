using app.Leiloeira.Artigos;
using app.Leiloeira.Lances;
using app.Leiloeira.Leiloes;
using app.Leiloeira.Pessoas;

namespace app.Data
{
    public class DatabaseFacade : IDatabaseFacade
    {
        private ArtigoDAO artigoDAO;
        private LanceDAO lanceDAO;
        private LeilaoDAO leilaoDAO;
        private PessoaDAO pessoaDAO;

        public DatabaseFacade() 
        { 
            this.artigoDAO = ArtigoDAO.getInstance();
            this.lanceDAO = LanceDAO.getInstance();
            this.leilaoDAO = LeilaoDAO.getInstance();
            this.pessoaDAO = PessoaDAO.getInstance();
        }

        //ARTIGOS//

        public bool ID_existe(int idArtigo){
            return this.artigoDAO.containsKey(idArtigo);
        }

        public bool Nome_existe(int idArtigo, string nome){
            return this.artigoDAO.get(idArtigo).getNome() == nome;
        }

        public bool Cond_existe(int idArtigo, string condicao){
            return this.artigoDAO.get(idArtigo).getCondicao() == condicao;
        }

        public bool Rarid_existe(int idArtigo, string raro){
            return this.artigoDAO.get(idArtigo).getRaridade() == raro;
        }

        public bool Art_existe(Artigo a)
        {
            return this.artigoDAO.containsValue(a);
        }

        public Artigo get_Artigo(int idArtigo)
        {
            return this.artigoDAO.get(idArtigo);
        }

        public void add_Artigo(Artigo a)
        {
            this.artigoDAO.put(a.getID(), a);
        }

        public void remove_Artigo(int idArtigo)
        {
            this.artigoDAO.remove(idArtigo);
        }

        public ICollection<Artigo> get_Artigos()
        {
            return this.artigoDAO.values();
        }

        public ICollection<int> get_IDsArtigos()
        {
            return this.artigoDAO.keys();
        }

        //LANCES//

        public bool IDLance_existe(int idLance){
            return this.lanceDAO.containsKey(idLance);
        }

        public bool IdLeilao_existe(int idLance, int idLeilao){
            return this.lanceDAO.get(idLance).getId_leilao() == idLeilao;
        }

        public bool IdLicitador_existe(int idLance, int IdLicitador){
            return this.lanceDAO.get(idLance).getId_Licitador() == IdLicitador;
        }

        public bool valorLance_existe(int idLance, decimal valor){
            return this.lanceDAO.get(idLance).getValor() == valor;
        }

        public bool Art_existe(Lance l)
        {
            return this.lanceDAO.containsValue(l);
        }

        public Lance get_Lance(int? idlance)
        {
            return this.lanceDAO.get(idlance);
        }

        public void add_Lance(Lance l)
        {
            this.lanceDAO.put(l.getID(), l);
        }

        public void remove_Lance(int idlance)
        {
            this.lanceDAO.remove(idlance);
        }

        public ICollection<Lance> get_Lances()
        {
            return this.lanceDAO.values();
        }

        public ICollection<int> get_IDsLance()
        {
            return this.lanceDAO.keys();
        }

        //LEILÕES//

        public bool IDLeilao_existe(int idLeilao){
            return this.leilaoDAO.containsKey(idLeilao);
        }

        public bool IdCriador_existe(int idLeilao, int idCriador){
            return this.leilaoDAO.get(idLeilao).getId_Criador() == idCriador;
        }

        public bool Descricao_existe(int idLeilao, string descricao){
            return this.leilaoDAO.get(idLeilao).getDescricao() == descricao;
        }

        public bool PReserva_existe(int idLeilao, decimal reserva){
            return this.leilaoDAO.get(idLeilao).getPrecoReserva() == reserva;
        }

        public bool PMinimo_existe(int idLeilao, decimal minimo){
            return this.leilaoDAO.get(idLeilao).getPrecoMinimo() == minimo;
        }

        public bool DataInicial_existe(int idLeilao, DateTime dataHoraInicial){
            return this.leilaoDAO.get(idLeilao).getDataHoraInicial().Equals(dataHoraInicial);
        }

        public bool Duracao_existe(int idLeilao, int d){
            return this.leilaoDAO.get(idLeilao).getDuracao() == d;
        }

        public bool IDLAtual_existe(int idLeilao, int l){
            return this.leilaoDAO.get(idLeilao).getIdLanceAtual() == l;
        }

        public bool Leilao_existe(Leilao l)
        {
            return this.leilaoDAO.containsValue(l);
        }

        public Leilao get_Leilao(int idLeilao)
        {
            return this.leilaoDAO.get(idLeilao);
        }

        public void add_Leilao(Leilao l)
        {
            this.leilaoDAO.put(l.getID(), l);
        }

        public void remove_Leilao(int idLeilao)
        {
            this.leilaoDAO.remove(idLeilao);
        }

        public ICollection<Leilao> get_Leiloes()
        {
            return this.leilaoDAO.values();
        }

        public ICollection<int> get_IDsLeiloes()
        {
            return this.leilaoDAO.keys();
        }

        public ICollection<Leilao> get_leiloes_nao_acabados()
        {
            return this.leilaoDAO.leiloes_nao_acabados();
        }

        public List<Artigo> get_artigos_leilao(int idLeilao)
        {
            return this.leilaoDAO.artigos_leilao(idLeilao);
        }

        public void update_id_lanceAtual(int id_leilao, int? id_lance)
        {
            this.leilaoDAO.update_id_lanceAtual(id_leilao, id_lance);
        }

        public void favoritar_leilao(int id_leilao, int id_utilizador)
        {
            this.leilaoDAO.favoritar_leilao(id_leilao, id_utilizador);
        }

        public void desfavoritar_leilao(int id_leilao, int id_utilizador)
        {
            this.leilaoDAO.desfavoritar_leilao(id_leilao, id_utilizador);
        }

        public bool e_favorito(int id_leilao, int id_utilizador) 
        {
            return this.leilaoDAO.e_favorito(id_leilao, id_utilizador);
        }

        public List<int> ids_favoritos(int id_utilizador)
        {
            return this.leilaoDAO.ids_favoritos(id_utilizador);
        }

        public List<Leilao> get_leiloes_favoritos(List<int> ids_favoritos)
        {
            return this.leilaoDAO.get_leiloes_favoritos(ids_favoritos);
        }

        public List<Leilao> get_leiloes_vencidos(int id_utilizador) 
        {
            return this.leilaoDAO.get_leiloes_vencidos(id_utilizador);
        }


        //PESSOAS//

        public bool IDPessoa_existe(int idPessoa){
            return this.pessoaDAO.containsKey(idPessoa);
        }

        public bool TPessoa_existe(int idPessoa, TipoDePessoa t){
            return this.pessoaDAO.get(idPessoa).getTipo() == t;
        }

        public bool Email_existe(int idPessoa, string e){
            return this.pessoaDAO.get(idPessoa).getEmail() == e;
        }

        public bool Pass_existe(int idPessoa, string p){
            return this.pessoaDAO.get(idPessoa).getPassword() == p;
        }

        public bool Saldo_existe(int idPessoa, decimal? saldo){
            return this.pessoaDAO.get(idPessoa).getSaldo() == saldo;
        }

        public bool Telemovel_existe(int idPessoa, int? t){
            return this.pessoaDAO.get(idPessoa).getTelemovel() == t;
        }

        public bool Nickname_existe(int idPessoa, string nickname){
            return this.pessoaDAO.get(idPessoa).getNickname() == nickname;
        }

        public bool Pessoa_existe(Pessoa p)
        {
            return this.pessoaDAO.containsValue(p);
        }

        public Pessoa get_Pessoa(int idPessoa)
        {
            return this.pessoaDAO.get(idPessoa);
        }

        public void add_Pessoa(Pessoa p)
        {
            this.pessoaDAO.put(p.getID(), p);
        }

        public void remove_Pessoa(int idPessoa)
        {
            this.pessoaDAO.remove(idPessoa);
        }

        public ICollection<Pessoa> get_Pessoas()
        {
            return this.pessoaDAO.values();
        }

        public int get_num_Pessoas()
        {
            return this.pessoaDAO.size();
        }

        public ICollection<int> get_IDsPessoas()
        {
            return this.pessoaDAO.keys();
        }

        public void update_saldo(int idPessoa, decimal? saldo)
        {
            this.pessoaDAO.update_saldo(idPessoa, saldo);
        }

        public void devolve_dinheiro_utilizador(int id_utilizador, decimal valor)
        {
            this.pessoaDAO.devolve_dinheiro_utilizador(id_utilizador, valor);
        }

        public decimal get_saldo(int id_utilizador)
        {
            return this.pessoaDAO.get_saldo(id_utilizador);
        }
    
    }
}