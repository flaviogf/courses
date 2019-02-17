package br.com.flaviofernandes.agenda.dao;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.annotation.NonNull;

import java.util.ArrayList;
import java.util.List;

import br.com.flaviofernandes.agenda.modelo.Aluno;

public class AlunoDAO extends SQLiteOpenHelper {
    public AlunoDAO(Context context) {
        super(context, "Agenda", null, 3);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        String sql = "CREATE TABLE Alunos(" +
                "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "nome TEXT NOT NULL, " +
                "endereco TEXT, " +
                "numero TEXT, " +
                "site TEXT, " +
                "nota REAL, " +
                "caminhoFoto TEXT);";
        sqLiteDatabase.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        String sql = "";

        switch (i) {
            case 1:
            case 2:
                sql = "ALTER TABLE Alunos ADD COLUMN caminhoFoto text";
                sqLiteDatabase.execSQL(sql);
        }
    }

    @NonNull
    private ContentValues pegaDadosAluno(Aluno aluno) {
        ContentValues contentValues = new ContentValues();
        contentValues.put("nome", aluno.getNome());
        contentValues.put("endereco", aluno.getEndereco());
        contentValues.put("numero", aluno.getNumero());
        contentValues.put("site", aluno.getSite());
        contentValues.put("nota", aluno.getNota());
        contentValues.put("caminhoFoto", aluno.getCaminhoFoto());
        return contentValues;
    }

    public void inserir(Aluno aluno) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues contentValues = pegaDadosAluno(aluno);

        db.insert("Alunos", null, contentValues);
    }

    public List<Aluno> buscarAlunos() {
        String sql = "SELECT * FROM Alunos";
        SQLiteDatabase db = getReadableDatabase();

        List<Aluno> alunos = new ArrayList<>();

        Cursor c = db.rawQuery(sql, null);

        while (c.moveToNext()) {
            Aluno aluno = new Aluno();
            aluno.setId(c.getLong(c.getColumnIndex("id")));
            aluno.setNome(c.getString(c.getColumnIndex("nome")));
            aluno.setEndereco(c.getString(c.getColumnIndex("endereco")));
            aluno.setNumero(c.getString(c.getColumnIndex("numero")));
            aluno.setSite(c.getString(c.getColumnIndex("site")));
            aluno.setNota(c.getDouble(c.getColumnIndex("nota")));
            aluno.setCaminhoFoto(c.getString(c.getColumnIndex("caminhoFoto")));

            alunos.add(aluno);
        }

        c.close();

        return alunos;
    }

    public void deletar(Aluno aluno) {
        SQLiteDatabase db = getWritableDatabase();

        String[] params = {aluno.getId().toString()};

        db.delete("Alunos", "id = ?", params);
    }

    public void alterar(Aluno aluno) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues contentValues = pegaDadosAluno(aluno);

        String[] params = {aluno.getId().toString()};

        db.update("Alunos", contentValues, "id = ?", params);
    }
}
