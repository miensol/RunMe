


task :one do
	puts "one"
	puts "one"
	puts "one"
	puts "one done"
end

desc "two description"
task :two do
	puts "two"
	print "two "
	puts "two done"
end

namespace :parent do
	task :nested_one do
		puts "nested_one done"
	end
	desc 'nested_two description'
	task :nested_two do
		puts "nested_two done"
	end
end