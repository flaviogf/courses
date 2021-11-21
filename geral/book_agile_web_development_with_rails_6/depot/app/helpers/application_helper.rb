module ApplicationHelper
  def render_if(record)
    result = yield if block_given?
    result ||= false
    render(record) if result
  end
end
