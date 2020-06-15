package br.com.flaviogf.technews.activities;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import br.com.flaviogf.technews.R;
import br.com.flaviogf.technews.adapters.NewsListAdapter;
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

        NewsService newsService = MemoryNewsService.getInstance();

        TechsViewModelFactory factory = new TechsViewModelFactory(newsService);

        viewModel = new ViewModelProvider(this, factory).get(TechsViewModel.class);
    }

    @Override
    protected void onResume() {
        super.onResume();
        fetchNews();
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
}
