package br.com.flaviogf.exemplos.exemplojavafx;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.layout.Pane;
import javafx.scene.layout.StackPane;
import javafx.stage.Stage;

public class Main extends Application {

    private Button botao;
    private Pane root;

    @Override
    public void start(Stage primaryStage) {
        botao = new Button();
        botao.setText("OK");
        botao.setOnMouseClicked(System.out::println);

        root = new StackPane();
        root.getChildren().add(botao);

        Scene cena = new Scene(root, 500f, 500f);

        primaryStage.setScene(cena);
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
