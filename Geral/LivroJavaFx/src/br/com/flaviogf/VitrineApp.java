package br.com.flaviogf;

import br.com.flaviogf.controllers.Carrinho;
import br.com.flaviogf.controllers.Vitrine;
import br.com.flaviogf.models.Produto;
import br.com.flaviogf.property.ItensProperty;
import br.com.flaviogf.utils.ProdutoUtils;
import javafx.application.Application;
import javafx.collections.FXCollections;
import javafx.collections.ListChangeListener;
import javafx.collections.ObservableList;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.BorderPane;
import javafx.stage.Stage;

import java.util.stream.Collectors;

public class VitrineApp extends Application {

    private BorderPane root;

    private TextField pesquisaField;
    private TableView<ItensProperty> tableView;

    private static ObservableList<ItensProperty> listaItens = FXCollections.observableArrayList();

    private static Carrinho carrinho = new Carrinho();
    private static Vitrine vitrine = new Vitrine();

    @Override
    public void start(Stage stage) {
        inicializaItens();
        inicializaComponentes();
        inicializaListeners();
        inicializaLayout();

        var cena = new Scene(root);

        stage.setResizable(false);
        stage.setScene(cena);
        stage.show();
    }

    private void inicializaItens() {
        vitrine.adiciona(
                new Produto("Bola topper", 15),
                new Produto("Luvas umbro", 9),
                new Produto("Camisa esportiva", 90)
        );
        vitrine.getProdutos()
                .stream()
                .map(ProdutoUtils::mapeaParaItensProperty)
                .forEach(listaItens::add);
    }

    private void inicializaComponentes() {
        pesquisaField = new TextField();
        pesquisaField.setPromptText("Produto");

        tableView = new TableView<>();
        tableView.setItems(listaItens);

        var produtoColumn = new TableColumn<ItensProperty, String>("Produto");
        produtoColumn.setCellValueFactory(new PropertyValueFactory<>("produto"));

        var precoColumn = new TableColumn<ItensProperty, Double>("Preço");
        precoColumn.setCellValueFactory(new PropertyValueFactory<>("preco"));

        tableView.getColumns().add(produtoColumn);
        tableView.getColumns().add(precoColumn);

        root = new BorderPane();
    }

    private void inicializaListeners() {
        tableView.getSelectionModel().getSelectedItems().addListener((ListChangeListener<ItensProperty>) change -> {
            try {
                ItensProperty itemSelecionado = tableView.getSelectionModel().getSelectedItem();
                ItemApp.setItemSelecionado(new Produto(itemSelecionado.getProduto(), itemSelecionado.getPreco()));
                new ItemApp().start(new Stage());
            } catch (NullPointerException ex) {
                System.out.println("nenhum dado selecionado");
            }
        });

        pesquisaField.setOnAction(event -> {
            var produtos = vitrine.filtra(pesquisaField.getText())
                    .stream()
                    .map(ProdutoUtils::mapeaParaItensProperty)
                    .collect(Collectors.toList());
            var itens = FXCollections.observableArrayList(produtos);
            tableView.setItems(itens);
        });
    }

    private void inicializaLayout() {
        root.setPrefSize(800, 600);
        root.setPadding(new Insets(10));
        root.setTop(pesquisaField);
        root.setCenter(tableView);
        BorderPane.setMargin(pesquisaField, new Insets(10, 0, 10, 0));
    }
}
