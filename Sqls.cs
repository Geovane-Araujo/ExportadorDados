using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportarDados
{
    class Sqls
    {
        private string clientes = "SELECT pessoas.ID ,pessoas.DataCadastro, pessoas.Nome , \n" +
            "\t (select RazaoSocial from pessoas_juridicas where pessoas_juridicas.IDPessoa = pessoas.id) as RazaoSocial , \n" +
            "\t (select DataNascimento From pessoas_fisicas Where pessoas_fisicas.IDPessoa = pessoas.ID) as DataNascimento ,\t\t\t\t\t\t \n" +
            "\t (select CPF from pessoas_fisicas where pessoas_fisicas.IDPessoa = pessoas.id) as CPF , \n" +
            "\t (select RG from pessoas_fisicas where pessoas_fisicas.IDPessoa = pessoas.id) as RG , \n" +
            "\t (select CNPJ from pessoas_juridicas where pessoas_juridicas.IDPessoa = pessoas.id) as CNPJ , \n" +
            "\t (select InscricaoEstadual from pessoas_juridicas where pessoas_juridicas.IDPessoa = pessoas.id) as InscricaoEstadual , \n" +
            "\t (select InscricaoMunicipal from pessoas_juridicas where pessoas_juridicas.IDPessoa = pessoas.id) as InscricaoMunicipal , \t\t\t\t\t\t \n" +
            "\t (select Fone from pessoas_telefones where Tipo = 0 and pessoas_telefones.IDPessoa = pessoas.id) AS Fone_Residencial , \n" +
            "\t (select Fone from pessoas_telefones where Tipo = 2 and pessoas_telefones.IDPessoa = pessoas.id) AS Fone_Celular , \n" +
            "\t (select Fone from pessoas_telefones where Tipo = 1 and pessoas_telefones.IDPessoa = pessoas.id) AS Fone_Comercial , \n" +
            "\t (select CEP from pessoas_enderecos where Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS CEP_Principal , \n" +
            "\t (select Endereco from pessoas_enderecos where Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS Endereco_Principal , \n" +
            "\t (select Bairro from pessoas_enderecos where Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS Bairro_Principal , \n" +
            "\t (select Complemento from pessoas_enderecos where Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS Complemento_Principal , \n" +
            "\t (select Numero from pessoas_enderecos where Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS Numero_Principal , \n" +
            "\t (select Nome from pessoas_enderecos INNER JOIN cidades ON pessoas_enderecos.IDCidade = cidades.ID where pessoas_enderecos.Tipo = 0 and pessoas_enderecos.IDPessoa = pessoas.id) AS Cidade_Principal , \n" +
            "\t (SELECT estados.Sigla FROM pessoas_enderecos INNER JOIN cidades ON pessoas_enderecos.IDCidade = cidades.ID INNER JOIN estados ON cidades.IDEstado = estados.ID WHERE (pessoas_enderecos.Tipo = 0) AND (pessoas_enderecos.IDPessoa = pessoas.id)) AS UF_Principal , \t\t\t\t\t\t \t\t\t\t\t\t \n" +
            "\t (select CEP from pessoas_enderecos where Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS CEP_Cobranca , \n" +
            "\t (select Endereco from pessoas_enderecos where Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS Endereco_Cobranca , \n" +
            "\t (select Bairro from pessoas_enderecos where Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS Bairro_Cobranca , \n" +
            "\t (select Complemento from pessoas_enderecos where Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS Complemento_Cobranca , \n" +
            "\t (select Numero from pessoas_enderecos where Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS Numero_Cobranca , \n" +
            "\t (select Nome from pessoas_enderecos INNER JOIN cidades ON pessoas_enderecos.IDCidade = cidades.ID where pessoas_enderecos.Tipo = 1 and pessoas_enderecos.IDPessoa = pessoas.id) AS Cidade_Cobranca , \n" +
            "\t (SELECT estados.Sigla FROM pessoas_enderecos INNER JOIN cidades ON pessoas_enderecos.IDCidade = cidades.ID INNER JOIN estados ON cidades.IDEstado = estados.ID WHERE (pessoas_enderecos.Tipo = 1) AND (pessoas_enderecos.IDPessoa = pessoas.id)) AS UF_Cobranca , \t\t\t\t\t\t  \n" +
            "\t (select EMail from pessoas_emails where pessoas_emails.Tipo = 0  and pessoas_emails.IDPessoa = Pessoas.ID) AS Email_Pessoal , \n" +
            "\t (select EMail from pessoas_emails where pessoas_emails.Tipo = 1  and pessoas_emails.IDPessoa = Pessoas.ID) AS Email_Cobranca , \n" +
            "\t pessoas_clientes.Inativo\n" +
            "\t FROM pessoas INNER JOIN\n" +
            "\t pessoas_clientes ON pessoas.ID = pessoas_clientes.IDPessoa";

        private string animais = "SELECT vet_animais.ID ,dono.ID as IDDONO, vet_animais.DataCadastro, dono.Nome AS [Dono], vet_animais.Nome as Animal, vet_animais.ChipNumero, vet_animais.Seguro, vet_animais.DataNascimento, \n" +
            "\t\t   CASE WHEN vet_animais.IDSexo = 0 THEN 'Macho' WHEN vet_animais.IDSexo = 1 THEN 'Fêmea' WHEN vet_animais.IDSexo = 2 THEN 'Macho - Castrado' WHEN vet_animais.IDSexo = 3 THEN 'Fêmea - Esterilizada' ELSE 'Indeterminado' END as Sexo, pessoas.Nome AS Veterinário, \n" +
            "           vet_racas.Descricao AS Raça, vet_especies.Descricao AS Espécie, vet_habitats.Descricao AS Habitat, vet_cores.Descricao AS Cor, vet_temperamentos.Descricao AS Temperamento, \n" +
            "           vet_pelos.Descricao AS Pelo, vet_condicoes.Descricao AS Condição, vet_membros.Descricao AS Membros, vet_estados.Descricao AS Estado, vet_dietas.Descricao AS Dieta, \n" +
            "           vet_obitos.Descricao AS DescricaoObito, vet_estaturas.Descricao AS Estatura, vet_olhos.Descricao AS Olhos, CASE WHEN vet_animais.Inativo = 0 THEN 'Não' ELSE 'Sim' END AS Inativo \n" +
            "           FROM vet_animais INNER JOIN\n" +
            "           vet_condicoes ON vet_animais.IDCondicao = vet_condicoes.ID INNER JOIN\n" +
            "           vet_cores ON vet_animais.IDCor = vet_cores.ID INNER JOIN\n" +
            "           vet_dietas ON vet_animais.IDDieta = vet_dietas.ID INNER JOIN\n" +
            "           vet_especies ON vet_animais.IDEspecie = vet_especies.ID INNER JOIN\n" +
            "           vet_estados ON vet_animais.IDEstado = vet_estados.ID INNER JOIN\n" +
            "           vet_estaturas ON vet_animais.IDEstatura = vet_estaturas.ID INNER JOIN\n" +
            "           vet_habitats ON vet_animais.IDHabitat = vet_habitats.ID INNER JOIN\n" +
            "           vet_membros ON vet_animais.IDMembros = vet_membros.ID INNER JOIN\n" +
            "           vet_obitos ON vet_animais.IDObito = vet_obitos.ID INNER JOIN\n" +
            "           vet_olhos ON vet_animais.IDOlhos = vet_olhos.ID INNER JOIN\n" +
            "           vet_pelos ON vet_animais.IDPelo = vet_pelos.ID INNER JOIN\n" +
            "           vet_racas ON vet_animais.IDRaca = vet_racas.ID INNER JOIN\n" +
            "           vet_temperamentos ON vet_animais.IDTemperamento = vet_temperamentos.ID INNER JOIN\n" +
            "           pessoas ON vet_animais.IDVeterinario = pessoas.ID  INNER JOIN\n" +
            "           pessoas AS dono ON vet_animais.IDDono = dono.ID\n" +
            "           where vet_animais.ID > 0";

        private string produtos = "SELECT produtos.ID , produtos.Descricao , ncm.NCM , produtos.ValorCusto ,produtos.EstoqueAtual, produtos.ValorVendaVista as ValorVenda,  produtos.DescontoPermitido , produtos.CodigoBarras , produtos_grupos_subgrupos.CodigoEspecifico + ' - ' + produtos_grupos_subgrupos.Descricao AS Grupo , \n" +
            "            produtos_marcas.Descricao AS Marca , produtos_locais_armazenamento.CodigoEspecifico + ' - ' + produtos_locais_armazenamento.Descricao AS Armazenamento , produtos_unidades.Abreviatura AS Unidade , CASE WHEN produtos.Inativo = 0 THEN 'Não' ELSE 'Sim' END AS Inativo , CASE WHEN produtos.Tipo = 0 THEN 'Produto' ELSE 'Serviço' END AS Tipo\n" +
            "            FROM produtos INNER JOIN produtos_grupos_subgrupos ON produtos.IDGrupo = produtos_grupos_subgrupos.ID INNER JOIN\n" +
            "            produtos_locais_armazenamento ON produtos.IDLocalArmazenamento = produtos_locais_armazenamento.ID INNER JOIN\n" +
            "            produtos_marcas ON produtos.IDMarca = produtos_marcas.ID INNER JOIN produtos_unidades ON produtos.IDUnidadeComercial = produtos_unidades.ID\n" +
            "            INNER JOIN ncm ON produtos.IDNcm = ncm.ID WHERE (produtos.IDSistemaContexto = -1 or produtos.IDSistemaContexto = 0 or produtos.IDSistemaContexto = -10);";

        private string receitas= "SELECT        dbo.NFe.ID, dbo.pessoas.Nome AS Pessoa_Destino, dbo.NFe.NumDoc_Gestao, dbo.NFe.B06_mod, dbo.NFe.B04_natOp, dbo.NFe.B08_nNF, dbo.NFe.B09_dhEmi, dbo.NFe.B10_dhSaiEnt, dbo.NFe_identificacao_destinatario.E02_CNPJ, \n" +
            "                         dbo.NFe_identificacao_destinatario.E03_CPF, vendedor.Nome AS Vendedor, dbo.plano_contas.CodigoEspecifico + ' - ' + dbo.plano_contas.Descricao AS PlanoContas, \n" +
            "                         dbo.centro_custo_lucro.CodigoEspecifico + ' - ' + dbo.centro_custo_lucro.Descricao AS CentroCustoLucro, dbo.NFe_total.W07_vProd\n" +
            "\tFROM            dbo.NFe INNER JOIN\n" +
            "                         dbo.NFe_identificacao_destinatario ON dbo.NFe.ID = dbo.NFe_identificacao_destinatario.IDNota INNER JOIN\n" +
            "                         dbo.pessoas ON dbo.NFe_identificacao_destinatario.IDPessoaDestinatario_Gestao = dbo.pessoas.ID INNER JOIN\n" +
            "                         dbo.centro_custo_lucro ON dbo.NFe.IDCC_Gestao = dbo.centro_custo_lucro.ID INNER JOIN\n" +
            "                         dbo.plano_contas ON dbo.NFe.IDPC_Gestao = dbo.plano_contas.ID INNER JOIN\n" +
            "                         dbo.pessoas AS vendedor ON dbo.NFe.IDVendedor_Gestao = vendedor.ID INNER JOIN\n" +
            "                         dbo.NFe_total ON dbo.NFe.ID = dbo.NFe_total.IDNota\n" +
            "\tWHERE        (dbo.NFe.B11_tpNF = 1) AND (dbo.NFe.ID > 1);";

        private string despesas = "SELECT dbo.NFe.ID, dbo.pessoas.Nome AS Pessoa_Emitente, CASE WHEN dbo.NFe_transporte.StatusEntrega = 0 THEN 'Entregue' ELSE 'Aguardando Entrega' END AS Entrega, dbo.NFe.NumDoc_Gestao, dbo.NFe.B06_mod, dbo.NFe.B04_natOp, dbo.NFe.B08_nNF, dbo.NFe.B09_dhEmi, \n" +
            "             dbo.NFe.B10_dhSaiEnt, dbo.NFe_identificacao_emitente.C02_CNPJ, dbo.NFe_identificacao_emitente.C02a_CPF, vendedor.Nome AS Vendedor, dbo.plano_contas.CodigoEspecifico + ' - ' + dbo.plano_contas.Descricao AS PlanoContas, \n" +
            "             dbo.centro_custo_lucro.CodigoEspecifico + ' - ' + dbo.centro_custo_lucro.Descricao AS CentroCustoLucro, dbo.NFe_total.W07_vProd\n" +
            "\tFROM   dbo.NFe INNER JOIN\n" +
            "             dbo.NFe_identificacao_emitente ON dbo.NFe.ID = dbo.NFe_identificacao_emitente.IDNota INNER JOIN\n" +
            "             dbo.pessoas ON dbo.NFe_identificacao_emitente.IDPessoaEmitente_Gestao = dbo.pessoas.ID INNER JOIN\n" +
            "             dbo.centro_custo_lucro ON dbo.NFe.IDCC_Gestao = dbo.centro_custo_lucro.ID INNER JOIN\n" +
            "             dbo.plano_contas ON dbo.NFe.IDPC_Gestao = dbo.plano_contas.ID INNER JOIN\n" +
            "             dbo.pessoas AS vendedor ON dbo.NFe.IDVendedor_Gestao = vendedor.ID INNER JOIN\n" +
            "             dbo.NFe_total ON dbo.NFe.ID = dbo.NFe_total.IDNota LEFT OUTER JOIN\n" +
            "             dbo.NFe_transporte ON dbo.NFe.ID = dbo.NFe_transporte.IDNota\n" +
            "\tWHERE (dbo.NFe.B11_tpNF = 0) AND (dbo.NFe.ID > 1);";

        private string consultas = "SELECT        dbo.vet_consultas.ID, Dono.Nome AS Dono, dbo.vet_animais.Nome AS Animal, dbo.vet_consultas.Data, dbo.produtos.Descricao AS TipoConsulta, Atendente.Nome AS Executor, dbo.vet_consultas.Peso, \n" +
            "                         dbo.vet_consultas.Anamnese, dbo.vet_consultas.ExameFisico AS [Exame Físico], dbo.vet_consultas.Diagnostico AS Diagnóstico, dbo.vet_consultas.Terapia, \n" +
            "                         dbo.faturamento.Quantidade * dbo.faturamento.ValorUnitario AS Valor, \n" +
            "                         CASE WHEN dbo.faturamento.Status = 0 THEN 'Pendente' WHEN dbo.faturamento.Status = 1 THEN 'A Faturar' WHEN dbo.faturamento.Status = 2 THEN 'Faturado' WHEN dbo.faturamento.Status = 98 THEN 'Sem Cobrança' ELSE ''\n" +
            "                          END AS Faturado\n" +
            "\tFROM            dbo.produtos INNER JOIN\n" +
            "                         dbo.vet_consultas INNER JOIN\n" +
            "                         dbo.vet_animais ON dbo.vet_consultas.IDAnimal = dbo.vet_animais.ID INNER JOIN\n" +
            "                         dbo.pessoas AS Dono ON dbo.vet_consultas.IDCliente = Dono.ID INNER JOIN\n" +
            "                         dbo.pessoas AS Atendente ON dbo.vet_consultas.IDAtendente = Atendente.ID ON dbo.produtos.ID = dbo.vet_consultas.IDTipoConsulta LEFT OUTER JOIN\n" +
            "                         dbo.faturamento ON dbo.vet_consultas.IDFaturamento = dbo.faturamento.ID;";

        private string vacinas = "SELECT        dbo.vet_vacinas.ID, dbo.pessoas.Nome AS Dono, dbo.vet_animais.Nome AS Animal, dbo.vet_vacinas.DataAgendamento, dbo.vet_vacinas.DataAplicacao, dbo.produtos.Descricao + ' - ' + dbo.vet_vacinas.Detalhe AS Vacina, \n" +
            "                         dbo.vet_vacinas.Detalhe, dbo.faturamento.Quantidade * dbo.faturamento.ValorUnitario AS Valor, Veterinario.Nome AS Executor, \n" +
            "                         CASE WHEN vet_vacinas.Status = 0 THEN 'Não Aplicada' WHEN vet_vacinas.Status = 1 THEN 'Aplicada' ELSE 'Cancelada' END AS Status, \n" +
            "                         CASE WHEN dbo.faturamento.Status = 0 THEN 'Pendente' WHEN dbo.faturamento.Status = 1 THEN 'A Faturar' WHEN dbo.faturamento.Status = 2 THEN 'Faturado' WHEN dbo.faturamento.Status = 98 THEN 'Sem Cobrança' ELSE ''\n" +
            "                          END AS Faturado\n" +
            "\tFROM            dbo.pessoas INNER JOIN\n" +
            "\t\t\t\t dbo.vet_animais INNER JOIN\n" +
            "\t\t\t\t dbo.vet_vacinas ON dbo.vet_animais.ID = dbo.vet_vacinas.IDAnimal INNER JOIN\n" +
            "\t\t\t\t dbo.pessoas AS Veterinario ON dbo.vet_vacinas.IDVeterinario = Veterinario.ID INNER JOIN\n" +
            "\t\t\t\t dbo.produtos_grades_estoque ON dbo.produtos_grades_estoque.ID = dbo.vet_vacinas.IDProduto INNER JOIN\n" +
            "\t\t\t\t dbo.produtos ON dbo.produtos_grades_estoque.IDProduto = dbo.produtos.ID ON dbo.pessoas.ID = dbo.vet_vacinas.IDCliente LEFT OUTER JOIN\n" +
            "\t\t\t\t dbo.faturamento ON dbo.vet_vacinas.IDFaturamento = dbo.faturamento.ID WHERE (vet_vacinas.ID > 0);";

        private string exames = "SELECT        dbo.vet_exames.ID, dbo.pessoas.Nome AS Dono, dbo.vet_animais.Nome AS Animal, dbo.vet_exames.Data, dbo.vet_analises_grupo.Descricao AS Exame, Solicitante.Nome AS Solicitante, \n" +
            "                         dbo.convenios_planos.Descricao AS [Convenio-Plano], dbo.faturamento.Quantidade * dbo.faturamento.ValorUnitario AS Valor, \n" +
            "                         CASE WHEN dbo.faturamento.Status = 0 THEN 'Pendente' WHEN dbo.faturamento.Status = 1 THEN 'A Faturar' WHEN dbo.faturamento.Status = 2 THEN 'Faturado' WHEN dbo.faturamento.Status = 98 THEN 'Sem Cobrança' ELSE ''\n" +
            "                          END AS Faturado\n" +
            "\tFROM            dbo.vet_analises_grupo INNER JOIN\n" +
            "                         dbo.vet_exames ON dbo.vet_analises_grupo.ID = dbo.vet_exames.IDGrupoAnalise INNER JOIN\n" +
            "                         dbo.vet_animais ON dbo.vet_exames.IDAnimal = dbo.vet_animais.ID INNER JOIN\n" +
            "                         dbo.convenios_planos ON dbo.vet_exames.IDConvenioPlano = dbo.convenios_planos.ID INNER JOIN\n" +
            "                         dbo.pessoas ON dbo.vet_exames.IDCliente = dbo.pessoas.ID INNER JOIN\n" +
            "                         dbo.pessoas AS Solicitante ON dbo.vet_exames.IDVeterinario = Solicitante.ID LEFT OUTER JOIN\n" +
            "                         dbo.faturamento ON dbo.vet_exames.IDFaturamento = dbo.faturamento.ID;";


        private string fornecedores = "SELECT        dbo.pessoas.ID, pessoas.DataCadastro, dbo.pessoas.Nome,\n" +
            "                             (SELECT        RazaoSocial\n" +
            "                               FROM            dbo.pessoas_juridicas\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS RazaoSocial,\n" +
            "                             (SELECT        CPF\n" +
            "                               FROM            dbo.pessoas_fisicas\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS CPF,\n" +
            "                             (SELECT        RG\n" +
            "                               FROM            dbo.pessoas_fisicas AS pessoas_fisicas_1\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS RG,\n" +
            "                             (SELECT        CNPJ\n" +
            "                               FROM            dbo.pessoas_juridicas AS pessoas_juridicas_3\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS CNPJ,\n" +
            "                             (SELECT        InscricaoEstadual\n" +
            "                               FROM            dbo.pessoas_juridicas AS pessoas_juridicas_2\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS InscricaoEstadual,\n" +
            "                             (SELECT        InscricaoMunicipal\n" +
            "                               FROM            dbo.pessoas_juridicas AS pessoas_juridicas_1\n" +
            "                               WHERE        (IDPessoa = dbo.pessoas.ID)) AS InscricaoMunicipal,\n" +
            "                             (SELECT        Fone\n" +
            "                               FROM            dbo.pessoas_telefones\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Fone_Residencial,\n" +
            "                             (SELECT        Fone\n" +
            "                               FROM            dbo.pessoas_telefones AS pessoas_telefones_2\n" +
            "                               WHERE        (Tipo = 2) AND (IDPessoa = dbo.pessoas.ID)) AS Fone_Celular,\n" +
            "                             (SELECT        Fone\n" +
            "                               FROM            dbo.pessoas_telefones AS pessoas_telefones_1\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Fone_Comercial,\n" +
            "                             (SELECT        CEP\n" +
            "                               FROM            dbo.pessoas_enderecos\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS CEP_Principal,\n" +
            "                             (SELECT        Endereco\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_13\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Endereco_Principal,\n" +
            "                             (SELECT        Bairro\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_12\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Bairro_Principal,\n" +
            "                             (SELECT        Complemento\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_11\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Complemento_Principal,\n" +
            "                             (SELECT        Numero\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_10\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Numero_Principal,\n" +
            "                             (SELECT        dbo.cidades.Nome\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_9 INNER JOIN\n" +
            "                                                         dbo.cidades ON pessoas_enderecos_9.IDCidade = dbo.cidades.ID\n" +
            "                               WHERE        (pessoas_enderecos_9.Tipo = 0) AND (pessoas_enderecos_9.IDPessoa = dbo.pessoas.ID)) AS Cidade_Principal,\n" +
            "                             (SELECT        dbo.estados.Sigla\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_8 INNER JOIN\n" +
            "                                                         dbo.cidades AS cidades_3 ON pessoas_enderecos_8.IDCidade = cidades_3.ID INNER JOIN\n" +
            "                                                         dbo.estados ON cidades_3.IDEstado = dbo.estados.ID\n" +
            "                               WHERE        (pessoas_enderecos_8.Tipo = 0) AND (pessoas_enderecos_8.IDPessoa = dbo.pessoas.ID)) AS UF_Principal,\n" +
            "                             (SELECT        CEP\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_7\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS CEP_Cobranca,\n" +
            "                             (SELECT        Endereco\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_6\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Endereco_Cobranca,\n" +
            "                             (SELECT        Bairro\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_5\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Bairro_Cobranca,\n" +
            "                             (SELECT        Complemento\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_4\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Complemento_Cobranca,\n" +
            "                             (SELECT        Numero\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_3\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Numero_Cobranca,\n" +
            "                             (SELECT        cidades_2.Nome\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_2 INNER JOIN\n" +
            "                                                         dbo.cidades AS cidades_2 ON pessoas_enderecos_2.IDCidade = cidades_2.ID\n" +
            "                               WHERE        (pessoas_enderecos_2.Tipo = 1) AND (pessoas_enderecos_2.IDPessoa = dbo.pessoas.ID)) AS Cidade_Cobranca,\n" +
            "                             (SELECT        estados_1.Sigla\n" +
            "                               FROM            dbo.pessoas_enderecos AS pessoas_enderecos_1 INNER JOIN\n" +
            "                                                         dbo.cidades AS cidades_1 ON pessoas_enderecos_1.IDCidade = cidades_1.ID INNER JOIN\n" +
            "                                                         dbo.estados AS estados_1 ON cidades_1.IDEstado = estados_1.ID\n" +
            "                               WHERE        (pessoas_enderecos_1.Tipo = 1) AND (pessoas_enderecos_1.IDPessoa = dbo.pessoas.ID)) AS UF_Cobranca,\n" +
            "                             (SELECT        Email\n" +
            "                               FROM            dbo.pessoas_emails\n" +
            "                               WHERE        (Tipo = 0) AND (IDPessoa = dbo.pessoas.ID)) AS Email_Pessoal,\n" +
            "                             (SELECT        Email\n" +
            "                               FROM            dbo.pessoas_emails AS pessoas_emails_1\n" +
            "                               WHERE        (Tipo = 1) AND (IDPessoa = dbo.pessoas.ID)) AS Email_Cobranca, dbo.pessoas_fornecedores.Inativo, dbo.fornecedores_funcoes.Descricao AS Função, dbo.fornecedores_grupos.Descricao AS Grupo\n" +
            "\t\t\t\t\t\t\t   \n" +
            "FROM            dbo.fornecedores_grupos INNER JOIN\n" +
            "                         dbo.fornecedores_funcoes INNER JOIN\n" +
            "                         dbo.pessoas INNER JOIN\n" +
            "                         dbo.pessoas_fornecedores ON dbo.pessoas.ID = dbo.pessoas_fornecedores.IDPessoa ON dbo.fornecedores_funcoes.ID = dbo.pessoas_fornecedores.IDFuncao ON \n" +
            "                         dbo.fornecedores_grupos.ID = dbo.pessoas_fornecedores.IDGrupo\n" +
            "WHERE        (dbo.pessoas.ID > 0) AND (dbo.pessoas_fornecedores.IDGrupo >= 0);";


        private string pacotes = "SELECT        dbo.vet_pacotes.ID, dbo.pessoas.Nome AS Dono, dbo.vet_animais.Nome AS Animal, dbo.vet_pacotes.DataAgendamento, dbo.vet_pacotes.DataAplicacao AS DataExecucao, \n" +
            "                         dbo.produtos.Descricao + ' - ' + dbo.vet_pacotes.Detalhe AS Pacote, dbo.vet_pacotes.Detalhe, dbo.faturamento.Quantidade * dbo.faturamento.ValorUnitario AS Valor, Veterinario.Nome AS Executor, \n" +
            "                         CASE WHEN vet_pacotes.Status = 0 THEN 'Não Executado' WHEN vet_pacotes.Status = 1 THEN 'Executado' ELSE 'Cancelado' END AS Status, \n" +
            "                         CASE WHEN dbo.faturamento.Status = 0 THEN 'Pendente' WHEN dbo.faturamento.Status = 1 THEN 'A Faturar' WHEN dbo.faturamento.Status = 2 THEN 'Faturado' WHEN dbo.faturamento.Status = 98 THEN 'Sem Cobrança' ELSE ''\n" +
            "                          END AS Faturado\n" +
            "FROM            dbo.pessoas INNER JOIN\n" +
            "                         dbo.vet_animais INNER JOIN\n" +
            "                         dbo.vet_pacotes ON dbo.vet_animais.ID = dbo.vet_pacotes.IDAnimal INNER JOIN\n" +
            "                         dbo.pessoas AS Veterinario ON dbo.vet_pacotes.IDVeterinario = Veterinario.ID INNER JOIN\n" +
            "                         dbo.produtos_grades_estoque ON dbo.produtos_grades_estoque.ID = dbo.vet_pacotes.IDProduto INNER JOIN\n" +
            "                         dbo.produtos ON dbo.produtos_grades_estoque.IDProduto = dbo.produtos.ID ON dbo.pessoas.ID = dbo.vet_pacotes.IDCliente LEFT OUTER JOIN\n" +
            "                         dbo.faturamento ON dbo.vet_pacotes.IDFaturamento = dbo.faturamento.ID;";




        public void PovoaSql(Hashtable tables)
        {

            tables.Add("clientes", clientes);
            tables.Add("animais", animais);
            tables.Add("produtos", produtos);
            tables.Add("receitas", receitas);
            tables.Add("despesas", despesas);
            tables.Add("consultas", consultas);
            tables.Add("vacinas", vacinas);
            tables.Add("exames", exames);
            tables.Add("fornecedores", fornecedores);
            tables.Add("pacotes", pacotes);
        }
    }
}
