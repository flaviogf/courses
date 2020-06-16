package br.com.flaviogf.technews.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.adapters.NewsListAdapter;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.MemoryNewsService;
import br.com.flaviogf.technews.service.NewsService;
import br.com.flaviogf.technews.viewmodels.TechsViewModel;
import br.com.flaviogf.technews.viewmodels.TechsViewModelFactory;

public class TechsActivity extends AppCompatActivity {
    private TechsViewModel viewModel;
    private NewsListAdapter adapter;
    private FloatingActionButton floatingActionButton;
    private ListView listView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_techs);

        adapter = new NewsListAdapter(this);
        floatingActionButton = findViewById(R.id.activity_techs_floating_action_button);
        listView = findViewById(R.id.activity_techs_list_view);

        floatingActionButton.setOnClickListener(view -> {
            Intent intent = new Intent(this, TechActivity.class);
            startActivity(intent);
        });

        listView.setAdapter(adapter);

        listView.setOnItemClickListener((adapterView, view, position, id) -> {
            Intent intent = new Intent(this, TechActivity.class);
            News news = adapter.getItem(position);
            intent.putExtra("@news-id", news.getId());
            startActivity(intent);
        });

        NewsService newsService = MemoryNewsService.getInstance();

        TechsViewModelFactory factory = new TechsViewModelFactory(newsService);

        viewModel = new ViewModelProvider(this, factory).get(TechsViewModel.class);

        registerForContextMenu(listView);
    }

    @Override
    protected void onResume() {
        super.onResume();
        fetchNews();
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        getMenuInflater().inflate(R.menu.activity_techs_context_menu, menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_techs_context_menu_remove:
                AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();

                News news = adapter.getItem(info.position);

                new AlertDialog.Builder(this)
                        .setTitle("Remove news")
                        .setMessage("Are you sure you want to remove this news?")
                        .setNegativeButton("Cancel", null)
                        .setPositiveButton("Confirm", ((dialogInterface, i) -> removeNews(news)))
                        .show();
                break;
        }

        return super.onContextItemSelected(item);
    }

    private void fetchNews() {
        viewModel.fetch().observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            adapter.update(result.getValue());
        });
    }

    private void removeNews(News news) {
        viewModel.remove(news).observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            adapter.remove(news);
        });
    }
}
