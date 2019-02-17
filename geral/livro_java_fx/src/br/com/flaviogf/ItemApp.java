package br.com.flaviogf;

import br.com.flaviogf.models.Produto;
import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.stage.Stage;

import static java.lang.String.valueOf;


public class ItemApp extends Application {

    private VBox root;
    private Label produtoField;
    private Label precoField;

    private static Produto itemSelecionado;

    @Override
    public void start(Stage stage) {
        inicializaComponentes();
        inicializaLayout();
        stage.setScene(new Scene(root));
        stage.setResizable(false);
        stage.sizeToScene();
        stage.show();
    }

    private void inicializaComponentes() {
        produtoField = new Label(itemSelecionado.getProduto());
        precoField = new Label(valueOf(itemSelecionado.getPreco()));
        root = new VBox();
        root.setPrefSize(400, 300);
        root.getChildren().addAll(produtoField, precoField);
    }

    private void inicializaLayout() {
        produtoField.setFont(new Font(32));
        precoField.setFont(new Font(20));
        root.setPadding(new Insets(10));
        root.setAlignment(Pos.TOP_CENTER);
        root.setSpacing(10);
    }

    public static void setItemSelecionado(Produto itemSelecionado) {
        ItemApp.itemSelecionado = itemSelecionado;
    }
}
