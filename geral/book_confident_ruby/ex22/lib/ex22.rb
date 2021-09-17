# frozen_string_literal: true

require 'ex22/null_logger'

module Ex22
  module_function

  def execute(logger=NullLogger.new)
    logger.info('Executing...')
  end
end
