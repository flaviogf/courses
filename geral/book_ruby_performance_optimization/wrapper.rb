require 'benchmark'
require 'json'

def measure
  no_gc = (ARGV[0] == '--no-gc')

  if no_gc
    GC.disable
  else
    GC.start
  end

  memory_before = `ps -o rss= -p #{Process.pid}`.to_i / 1024

  gc_stat_before = GC.stat

  time = Benchmark.realtime do
    yield
  end

  puts ObjectSpace.count_objects

  gc_stat_after = GC.stat

  memory_after = `ps -o rss= -p #{Process.pid}`.to_i / 1024

  data = {
    RUBY_VERSION => {
      gc: no_gc ? 'disabled' : 'enabled',
      time: time.round(2),
      gc_count: gc_stat_after[:count] - gc_stat_before[:count],
      memory: "#{memory_after - memory_before} MB"
    }
  }

  puts data.to_json
end
